using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public int number;
    public TargetMain targetMain;
    public bool active;

    public GameObject prev;
    public GameObject next;

    private bool direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("In!");
            //if (other.gameObject.GetComponent<PlayerMovement>().gate == number && targetMain.setGo)
            //{
            //    targetMain.rotMult = -targetMain.rotMult;
            //}
            //else
            //{
            //    targetMain.setGo = true;
            //}
            if (other.gameObject.GetComponent<PlayerMovement>().forward)
            {
                other.gameObject.GetComponent<PlayerMovement>().prevNode = gameObject;
                other.gameObject.GetComponent<PlayerMovement>().nextNode = next;
                targetMain.rotMult = -1;
            }
            else
            {
                other.gameObject.GetComponent<PlayerMovement>().prevNode = prev;
                other.gameObject.GetComponent<PlayerMovement>().nextNode = gameObject;
                targetMain.rotMult = 1;
            }

            other.gameObject.GetComponent<PlayerMovement>().gate = number;
            other.transform.rotation = other.transform.rotation * Quaternion.Euler(0, 30 * targetMain.rotMult, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            direction = other.gameObject.GetComponent<PlayerMovement>().forward;
            Debug.Log("In!");
            //if (other.gameObject.GetComponent<PlayerMovement>().gate == number && targetMain.setGo)
            //{
            //    targetMain.rotMult = -targetMain.rotMult;
            //}
            //else
            //{
            //    targetMain.setGo = true;
            //}
            if (direction)
            {
                other.gameObject.GetComponent<PlayerMovement>().prevNode = gameObject;
                other.gameObject.GetComponent<PlayerMovement>().nextNode = next;
                targetMain.rotMult = -1;
            }
            else
            {
                other.gameObject.GetComponent<PlayerMovement>().prevNode = prev;
                other.gameObject.GetComponent<PlayerMovement>().nextNode = gameObject;
                targetMain.rotMult = 1;
            }

            other.gameObject.GetComponent<PlayerMovement>().gate = number;
            other.transform.rotation = other.transform.rotation * Quaternion.Euler(0, 30 * targetMain.rotMult, 0);
        }

        else if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Got Enemy!");
            if (other.gameObject.GetComponent<EnemyController>().forward)
            {
                other.gameObject.GetComponent<EnemyController>().prevNode = gameObject;
                other.gameObject.GetComponent<EnemyController>().nextNode = next;
                other.gameObject.GetComponent<EnemyController>().rotMult = 1;
            }
            else
            {
                other.gameObject.GetComponent<EnemyController>().prevNode = prev;
                other.gameObject.GetComponent<EnemyController>().nextNode = gameObject;
                other.gameObject.GetComponent<EnemyController>().rotMult = -1;
            }
            other.transform.rotation = other.transform.rotation * Quaternion.Euler(0, 30 * targetMain.rotMult, 0);
        }
       else
        {
            Debug.Log("Hit something!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerMovement>().forward != direction)
            {
                direction = other.gameObject.GetComponent<PlayerMovement>().forward;
                if (direction)
                {
                    other.gameObject.GetComponent<PlayerMovement>().prevNode = gameObject;
                    other.gameObject.GetComponent<PlayerMovement>().nextNode = next;
                    targetMain.rotMult = -1;
                }
                else
                {
                    other.gameObject.GetComponent<PlayerMovement>().prevNode = prev;
                    other.gameObject.GetComponent<PlayerMovement>().nextNode = gameObject;
                    targetMain.rotMult = 1;
                }

                other.gameObject.GetComponent<PlayerMovement>().gate = number;
                other.transform.rotation = other.transform.rotation * Quaternion.Euler(0, 30 * targetMain.rotMult, 0);
                other.gameObject.GetComponent<PlayerMovement>().runRoutine();
            }
        }
    }
}
