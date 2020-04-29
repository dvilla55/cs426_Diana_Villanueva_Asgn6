using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic Movement System...

public class WaypointRead : MonoBehaviour
{
    public bool forward;
    public float speed;
    public GameObject nextNode;
    public GameObject prevNode;

    Rigidbody rb;

    Vector3 moveDirection;
    Vector3 target;
    float reload;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = transform.position;
        reload = moveDirection.y;

        if (forward)
        {
            target = nextNode.transform.position;
            target.y = transform.position.y;
            moveDirection = Vector3.MoveTowards(moveDirection, target, speed * Time.deltaTime);
            Vector3 look = nextNode.transform.position;
            look.y = transform.position.y;
            transform.LookAt(look);
        }
        else
        {
            target = prevNode.transform.position;
            target.y = transform.position.y;
            moveDirection = Vector3.MoveTowards(moveDirection, target, speed * Time.deltaTime);
            Vector3 look = prevNode.transform.position;
            look.y = transform.position.y;
            transform.LookAt(look);
        }

        moveDirection.y = reload;
        transform.position = moveDirection;
    }
}
