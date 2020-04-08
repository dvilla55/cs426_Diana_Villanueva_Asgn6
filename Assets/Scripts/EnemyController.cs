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

    private Vector3 target1;
    private Vector3 target2;

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
        Debug.Log("Pausing...");
        go = false;
        yield return new WaitForSeconds(2);
        go = true;
        yield return new WaitForSeconds(0);
    }

    private void checkChange()
    {
        if(last != direction)
        {
            StartCoroutine(pause());
            last = direction;
            forward = !forward;
        }
    }

    //Loot dropping
    public void drop()
    {
        if(item != null)
        {
            Instantiate(item, transform.position, transform.rotation);
        }
    }

    public void updateTargets()
    {
        target1 = prevNode.transform.position;
        target1.y = transform.position.y;

        target2 = nextNode.transform.position;
        target2.y = transform.position.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        target1 = prevNode.transform.position;
        target1.y = transform.position.y;

        target2 = nextNode.transform.position;
        target2.y = transform.position.y;
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
                moveDirection = Vector3.MoveTowards(moveDirection, target2, speed * Time.deltaTime);
            }
            else
            {
                moveDirection = Vector3.MoveTowards(moveDirection, target1, speed * Time.deltaTime);
            }
            //Debug.Log("Did not Hit");
        }

        //Update position
        moveDirection.y = reload;
        transform.position = moveDirection;
    }
}
