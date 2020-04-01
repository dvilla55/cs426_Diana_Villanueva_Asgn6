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
        transform.LookAt(target.transform);
        transform.position = new Vector3(target.transform.transform.position.x * 2, target.transform.transform.position.y + 6, target.transform.transform.position.z * 2);

    }
}
