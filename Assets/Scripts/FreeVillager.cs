using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeVillager : MonoBehaviour
{
    bool isFree;
    float time;
    public Material material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        isFree = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFree)
        {
            time += 1 * Time.deltaTime;

            if (time >= 5f)
            {
                removeCivilian();
            }
        }
    }

    public void removeCivilian()
    {
        Destroy(gameObject);
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rend.sharedMaterial = material;
            isFree = true;
        }
    }
}
