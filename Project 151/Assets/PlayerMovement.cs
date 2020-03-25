using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float jump;
    public float gravity;
    public float yCord;
    public bool forward = true;

    [Header("Supplementaries")]
    public CharacterController ctrl;
    public TargetMain targets;

    private Vector3 moveDirection;
    private float reload;

    public int gate;

    [SerializeField] private GameObject body;

    [Header("Collision Data")]
    public float FRay;
    public float GRay;

    [Header("Path Data")]
    public GameObject prevNode;
    public GameObject nextNode;

    // Start is called before the first frame update
    void Start()
    {
        ctrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //reload = moveDirection.y;
        //moveDirection = transform.forward * Input.GetAxis("Horizontal") * speed;
        //moveDirection.y = reload;

        if (Input.GetButtonDown("Jump") && ctrl.isGrounded)
        {
            moveDirection.y = jump;
        }
        else if (ctrl.isGrounded)
        {
            moveDirection.y = 0;
        }

        //moveDirection.y = moveDirection.y + (Physics.gravity.y * gravity);
        //ctrl.Move(moveDirection * Time.deltaTime);

        moveDirection = transform.position;
        reload = moveDirection.y;

        if(Input.GetKey(KeyCode.A))
        {
            forward = false;
            moveDirection = Vector3.MoveTowards(moveDirection, prevNode.transform.position, speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            forward = true;
            moveDirection = Vector3.MoveTowards(moveDirection, nextNode.transform.position, speed * Time.deltaTime);
        }

        moveDirection.y = reload;
        transform.position = moveDirection;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(body.transform.position, body.transform.forward * FRay);
    }
}
