using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public InventoryManager manager;
    private Animator anim;
    public int type;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(manager.Request(type))
        {
            anim.SetBool("open", true);
            Destroy(this);
        }
    }
}
