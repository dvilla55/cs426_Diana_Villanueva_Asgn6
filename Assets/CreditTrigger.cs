using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreditTrigger : MonoBehaviour
{
    public GameObject credits;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            credits.SetActive(true);
            AudioListener.pause = true;
            Destroy(other.gameObject);
        }
    }
}
