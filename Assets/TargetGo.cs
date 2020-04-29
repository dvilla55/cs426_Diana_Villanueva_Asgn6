using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGo : MonoBehaviour
{

    public GameObject target;
    public GameObject[] activate;
    public float speed;
    Vector3 go;
    Vector3 moveDirection;
    Vector3 set;
    float reload;

    // Start is called before the first frame update
    void Start()
    {
        if(set != null)
        {
            set = gameObject.transform.position;
        }
        gameObject.SetActive(true);
        if (activate != null)
        {
            activate[0].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x != target.transform.position.x) && (transform.position.z != target.transform.position.z))
        {
            moveDirection = transform.position;
            reload = moveDirection.y;

            go = target.transform.position;
            go.y = transform.position.y;
            moveDirection = Vector3.MoveTowards(moveDirection, go, speed * Time.deltaTime);
            Vector3 look = target.transform.position;
            look.y = transform.position.y;
            transform.LookAt(look);

            moveDirection.y = reload;
            transform.position = moveDirection;
        }
        else
        {
            gameObject.SetActive(false);
            if(activate[0] != null)
            {
                activate[0].SetActive(true);
                activate[1].SetActive(false);
                activate[2].SetActive(false);
            }
        }

    }
}
