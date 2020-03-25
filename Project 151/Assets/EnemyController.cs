using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemies should not go between floors, that means they should not travel up or down

public class EnemyController : MonoBehaviour
{
    public Vector3 moveDirection;
    public float reload;
    public float speed;
    public GameObject prevNode;
    public GameObject nextNode;

    public float rayDist;

    public bool forward = true;
    public int rotMult = 1;

    RaycastHit hit;

    int mask = 1 << 9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = transform.position;
        reload = moveDirection.y;

        //Raycasting (Detects when the enemy has found the Player, stops when it has)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDist, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDist, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDist, Color.white);
            moveDirection = Vector3.MoveTowards(moveDirection, nextNode.transform.position, speed * Time.deltaTime);
            Debug.Log("Did not Hit");
        }



        

        moveDirection.y = reload;
        transform.position = moveDirection;
    }
}
