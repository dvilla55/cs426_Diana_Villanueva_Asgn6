using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float despawnTime;


    IEnumerator despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        Object.Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(despawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
