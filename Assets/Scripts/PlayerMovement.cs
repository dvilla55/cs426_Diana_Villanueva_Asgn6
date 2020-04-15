using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float yCord;
    public bool forward = true;
    public Vector3 target;
    public float stepTime;

    [Header("Jump")]
    public Rigidbody rb;
    public bool OnGround;
    public bool barrier;
    public LayerMask groundLayer;
    public float detectLength;
    public float jump;
    public float gravity;
    public float fallMult;
    private bool canJump = true;
    public Rigidbody Projectile;

    [Header("Supplementaries")]
    public CharacterController ctrl;
    public TargetMain targets;
    public AudioSource sfx;
    [SerializeField] float time;
    bool walking = false;

    private Vector3 moveDirection;
    private float reload;

    public int gate;

    [SerializeField] private GameObject body;
    private Animator anim;
    public Animator motion;
    public Animator shell;

    [Header("VFX")]
    public ParticleSystem run;
    public ParticleSystem launch;

    [Header("Collision Data")]
    public float FRay;


    [Header("Path Data")]
    public GameObject prevNode;
    public GameObject nextNode;

    IEnumerator sound;

    public IEnumerator steps()
    {
        while(true)
        {
            if (speed == 5f)
            {
                time = stepTime;
            }
            else
            {
                time = stepTime / 3f;
            }
            sfx.pitch = Random.Range(0.9f, 1.1f);
            sfx.Play();

            yield return new WaitForSeconds(time);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sound = steps();
        ctrl = GetComponent<CharacterController>();
        anim = body.GetComponent<Animator>();
        anim.SetBool("Forward", forward);
    }

    // Update is called once per frame
    void Update()
    {
        OnGround = Physics.Raycast(transform.position, Vector3.down, detectLength, groundLayer);
        moveDirection = transform.position;

        //Run when hold left shift
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
            motion.SetInteger("speed", 10);
        }
        else
        {
            speed = 5f;
            motion.SetInteger("speed", 5);
        }

        //On Ground, Jump, and Gravity
        if(OnGround)
        {
            canJump = true;
            shell.SetBool("grounded", true);
            shell.SetBool("canJump", true);

            rb.useGravity = false;

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
                shell.SetBool("grounded", false);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canJump)
            {
                canJump = false;
                shell.SetBool("canJump", false);
                Jump();
            }
            Vector3 phys = gravity * fallMult * Vector3.down;
            rb.AddForce(phys, ForceMode.Acceleration);
        }
        reload = moveDirection.y;

        //Moving left and right
        if (Input.GetKey(KeyCode.A))
        {
            forward = false;
            anim.SetBool("Forward", forward);
            target = prevNode.transform.position;
            target.y = transform.position.y;
            moveDirection = Vector3.MoveTowards(moveDirection, target, speed * Time.deltaTime);

            //Walking sounds
            if (OnGround && !walking)
            {
                StartCoroutine(sound);
                walking = true;
            }
            else if (!OnGround)
            {
                StopCoroutine(sound);
                walking = false;
            }

            if(speed == 10 && OnGround)
            {
                run.enableEmission = true;
            }
            else
            {
                run.enableEmission = false;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            forward = true;
            anim.SetBool("Forward", forward);
            target = nextNode.transform.position;
            target.y = transform.position.y;
            moveDirection = Vector3.MoveTowards(moveDirection, target, speed * Time.deltaTime);

            //Walking sounds
            if (OnGround && !walking)
            {
                StartCoroutine(sound);
                walking = true;
            }
            else if(!OnGround)
            {
                StopCoroutine(sound);
                walking = false;
            }

            if (speed == 10 && OnGround)
            {
                run.enableEmission = true;
            }
            else
            {
                run.enableEmission = false;
            }
        }
        else
        {
            motion.SetInteger("speed", 0);
            //Walking sounds
            StopCoroutine(sound);
            walking = false;
        }

        //Update position
        moveDirection.y = reload;
        transform.position = moveDirection;

        //Bullet Functions
        if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(Projectile, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation) as Rigidbody;
            Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), GetComponent<Collider>());

            if(forward)
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 100f));
            else
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, -100f));

        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        launch.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(body.transform.position, body.transform.forward * FRay);
        Gizmos.DrawRay(transform.position, Vector3.down * detectLength);
    }
}
