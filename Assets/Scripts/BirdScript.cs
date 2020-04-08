using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    private Vector3 moveDirection;
    private Vector3 startingPostion;
    public float speed;
    //direction is up or down -1 being down
    int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        startingPostion = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (direction == -1 && startingPostion.y - 5f >= transform.position.y)
        {
            direction = 1;
        }
        else if (direction == 1 && startingPostion.y <= transform.position.y)
        {
            direction = -1;
            GetComponent<AudioSource>().Play();
        }



        transform.position = new Vector3(transform.position.x, transform.position.y + 3f * Time.deltaTime * direction, transform.position.z);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
