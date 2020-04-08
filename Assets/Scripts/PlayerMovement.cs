using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float gravity;
    public float yCord;
    public bool forward = true;
    public Vector3 target;

    [Header("Jump")]
    public Rigidbody rb;
    public bool OnGround;
    public LayerMask groundLayer;
    public float detectLength;
    public float jump;
    public Rigidbody Projectile;

    [Header("Supplementaries")]
    public CharacterController ctrl;
    public TargetMain targets;

    private Vector3 moveDirection;
    private float reload;

    public int gate;

    [SerializeField] private GameObject body;
    private Animator anim;

    [Header("Collision Data")]
    public float FRay;


    [Header("Path Data")]
    public GameObject prevNode;
    public GameObject nextNode;

    // Start is called before the first frame update
    void Start()
    {
        ctrl = GetComponent<CharacterController>();
        anim = body.GetComponent<Animator>();
        anim.SetBool("Forward", forward);
    }

    // Update is called once per frame
    void Update()
    {
        OnGround = Physics.Raycast(transform.position, Vector3.down, detectLength, groundLayer);
        moveDirection = transform.position;

        if(Input.GetButtonDown("Jump") && OnGround)
        {
            Jump();
        }
        reload = moveDirection.y;

        if(Input.GetKey(KeyCode.A))
        {
            forward = false;
            anim.SetBool("Forward", forward);
            target = prevNode.transform.position;
            target.y = transform.position.y;
            moveDirection = Vector3.MoveTowards(moveDirection, target, speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            forward = true;
            anim.SetBool("Forward", forward);
            target = nextNode.transform.position;
            target.y = transform.position.y;
            moveDirection = Vector3.MoveTowards(moveDirection, target, speed * Time.deltaTime);
        }

        moveDirection.y = reload;
        transform.position = moveDirection;

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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(body.transform.position, body.transform.forward * FRay);
        Gizmos.DrawRay(transform.position, Vector3.down * detectLength);
    }
}
