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

    public bool go = true;

    [Header("Inventory")]
    public GameObject item;

    //Edge and Direction monitor
    public int direction = 0;
    public int last = 0;

    RaycastHit hit;

    int mask = 1 << 9;

    //Pause
    IEnumerator pause()
    {
        go = false;
        yield return new WaitForSeconds(3);
        go = true;
        yield return new WaitForSeconds(0);
    }

    private void checkChange()
    {
        if(last != direction)
        {
            StartCoroutine(pause());
        }
    }

    //Loot dropping
    public void drop()
    {
        Instantiate(item, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkChange();
        if(forward)
        transform.LookAt(new Vector3(nextNode.transform.position.x, transform.position.y, nextNode.transform.position.z));
        else
            transform.LookAt(new Vector3(prevNode.transform.position.x, transform.position.y, prevNode.transform.position.z));

        //Get initial position
        moveDirection = transform.position;
        reload = moveDirection.y;

        //Raycasting (Detects when the enemy has found the Player, stops when it has)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDist, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDist, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else if(go)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDist, Color.white);
            if(direction == 0)
            {
                moveDirection = Vector3.MoveTowards(moveDirection, nextNode.transform.position, speed * Time.deltaTime);
            }
            else
            {
                moveDirection = Vector3.MoveTowards(moveDirection, prevNode.transform.position, speed * Time.deltaTime);
            }
            //Debug.Log("Did not Hit");
        }

        //Update position
        moveDirection.y = reload;
        transform.position = moveDirection;
    }
}
