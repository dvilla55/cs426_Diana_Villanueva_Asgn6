using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsScript : MonoBehaviour
{
    public FreeVillager open;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(open.isFree)
        {
            anim.SetBool("open", open);
            Destroy(this);
        }
    }
}
