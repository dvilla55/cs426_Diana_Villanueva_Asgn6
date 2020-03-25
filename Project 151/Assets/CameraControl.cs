using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public Vector3 rotOff;

    public int gateNum;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
        transform.eulerAngles = target.transform.eulerAngles + rotOff;
    }
}
