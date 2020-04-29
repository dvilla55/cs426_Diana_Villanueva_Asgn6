using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    [SerializeField] Animator a;
    [SerializeField] CreditTrigger b;
    bool goOnce = false;

    IEnumerator delayLoad()
    {
        yield return new WaitForSeconds(4f);
        b.doCred();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !goOnce)
        {
            goOnce = true;
            a.SetBool("en", true);
            StartCoroutine(delayLoad());
        }
    }


}
