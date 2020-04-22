using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] GameObject spawn;
    bool walking = false;
    public PlayerHealth health;
    public Slider scale;

    private Vector3 moveDirection;
    private float reload;

    public int gate;

    [SerializeField] private GameObject body;
    private Animator anim;
    public Animator motion;
    public Animator shell;
    public Animator swing;

    [Header("VFX")]
    public ParticleSystem run;
    public ParticleSystem launch;
    public GameObject weapon;

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
        health = GetComponent<PlayerHealth>();
        anim.SetBool("Forward", forward);
    }

    // Update is called once per frame
    void Update()
    {
        swing.SetBool("swing", false);

        if (health.isDead)
        {
            motion.SetBool("DEAD", true);
            weapon.AddComponent<Rigidbody>();
            Rigidbody t = weapon.GetComponent<Rigidbody>();
            t.isKinematic = false;
            t.useGravity = true;
            t.mass = 1;

            Destroy(this);
        }

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
        //else if (Input.GetKey(KeyCode.L))
        //{
        //    rb.AddForce(body.transform.forward * 25, ForceMode.Force);
        //}
        else
        {
            motion.SetInteger("speed", 0);
            //Walking sounds
            StopCoroutine(sound);
            walking = false;
        }

        //Update position
        moveDirection.y = reload;
        //transform.position = moveDirection;
        rb.MovePosition(moveDirection);

        //Bullet Functions
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(Projectile, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), transform.rotation) as Rigidbody;
            Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), GetComponent<Collider>());

            if (scale.value > 0)
            {
                instantiatedProjectile.GetComponent<Light>().color = new Color(1f, 0.8053272f, 0.3915094f);
                instantiatedProjectile.transform.GetChild(1).GetComponent<ParticleSystem>().startColor = new Color(1f, 0.8053272f, 0.3915094f);
            }
            else if (scale.value < 0)
            {
                instantiatedProjectile.GetComponent<Light>().color = new Color(0.7013627f, 0.2923638f, 0.8490566f);
                instantiatedProjectile.transform.GetChild(1).GetComponent<ParticleSystem>().startColor = new Color(0.7013627f, 0.2923638f, 0.8490566f);
            }

            //if(forward)
            //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 100f));
            //else
            //    instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, -100f));

            WaypointRead read = instantiatedProjectile.gameObject.GetComponent<WaypointRead>();
            read.forward = forward;
            read.nextNode = nextNode;
            read.prevNode = prevNode;

        }

        if(Input.GetButtonDown("Fire2"))
        {
            swing.SetBool("swing", true);
        }
    }

    private void FixedUpdate()
    {
        //On Ground, Jump, and Gravity
        if (OnGround)
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
