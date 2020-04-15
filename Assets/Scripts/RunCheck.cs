using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCheck : MonoBehaviour
{

    public PlayerMovement motion;
    public ParticleSystem pat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (motion.speed == 10)
        {
            pat.enableEmission = true;
        }
        else
        {
            pat.enableEmission = false;
        }
    }
}
