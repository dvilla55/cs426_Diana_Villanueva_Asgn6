using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public GameObject target;
    //public Vector3 offset;
    //public Vector3 rotOff;
    public double maxY;
    public float smoothSpeed = 0.1f;

    public int gateNum;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (maxY > target.transform.transform.position.y + 6)
        {
            Vector3 newDest = new Vector3(target.transform.position.x * 2, target.transform.position.y + 6, target.transform.position.z * 2);


            Vector3 smoothedPosition = Vector3.Lerp(transform.position, newDest, smoothSpeed);

            transform.position = smoothedPosition;

            transform.LookAt(target.transform);
        }

    }
}
