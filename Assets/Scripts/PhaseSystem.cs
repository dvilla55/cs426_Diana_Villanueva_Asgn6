using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseSystem : MonoBehaviour
{
 
    float time;
    public int currPhase;
    [SerializeField] int add = -1;
    bool hasFullMoonOccured = false;
    public float phaseTime;
    public Text phase;
    public Animator anim;
    public Animator moon;

    IEnumerator phaseTimer()
    {
        while(true)
        {
            if(currPhase == 3 || currPhase == 0)
            {
                add = -add;
            }
            currPhase += add;
            yield return new WaitForSeconds(phaseTime);
            phaseChange();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        currPhase = 0;
        phaseChange();
        StartCoroutine(phaseTimer());
    }

    // Update is called once per frame
    void Update()
    {
        //IEnumerator phaseTimer with editor adjustable phaseTime for easier testing
    }

    void phaseChange(){

        //Note: We visit the crescent & half moon phases twice and have two possible phases from them

        switch (currPhase)
        {
            case 0:
                phase.text = "Current Phase: New Moon";
                anim.SetInteger("phase", currPhase);
                moon.SetInteger("phase", currPhase);
                break;
            case 1:
                phase.text = "Current Phase: Crescent Moon";
                anim.SetInteger("phase", currPhase);
                moon.SetInteger("phase", currPhase);
                break;
            case 2:
                phase.text = "Current Phase: Half Moon";
                anim.SetInteger("phase", currPhase);
                moon.SetInteger("phase", currPhase);
                break;
            case 3:
                phase.text = "Current Phase: Full Moon";
                anim.SetInteger("phase", currPhase);
                moon.SetInteger("phase", currPhase);
                break;
        }
        return;
    }

    public int getPhase()
    {
        return currPhase;
    }
}
