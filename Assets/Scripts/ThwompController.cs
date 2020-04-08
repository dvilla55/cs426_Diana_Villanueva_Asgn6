using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemies should not go between floors, that means they should not travel up or down

public class ThwompController : MonoBehaviour
{
   
    public GameObject prevNode;
    public GameObject nextNode;
    public GameObject player;
   
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
        if(player.GetComponent<PlayerMovement>().nextNode==nextNode&&player.GetComponent<PlayerMovement>().prevNode==prevNode)
            {
            if (transform.position.x < player.transform.position.x)
                transform.position = new Vector3(transform.position.x + 3f * Time.deltaTime, transform.position.y, transform.position.z);
            else if (transform.position.x > player.transform.position.x)
            {
                transform.position = new Vector3(transform.position.x - 3f * Time.deltaTime, transform.position.y, transform.position.z);
            }

            if (transform.position.z < player.transform.position.z)
                transform.position = new Vector3(transform.position.x  , transform.position.y, transform.position.z+ 3f* Time.deltaTime);
            else if (transform.position.z > player.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - 3f * Time.deltaTime);
            }
        }


          
       
    }
}