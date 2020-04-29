using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreditTrigger : MonoBehaviour
{
    public GameObject credits;

    public void doCred()
    {
        credits.SetActive(true);
        AudioListener.pause = true;
    }
}
