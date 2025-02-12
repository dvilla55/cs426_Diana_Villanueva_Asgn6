﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedestal : MonoBehaviour
{
    public AudioSource sound;
    public GameObject hint;
    public float fadeAmnt;
    public int add;

    [SerializeField] Slider scale;

    IEnumerator fade;
    Color check;

    IEnumerator inOut(float target, float tick)
    {
        while(sound.volume != target)
        {
            sound.volume += tick;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (fade != null)
            {
                StopCoroutine(fade);
            }
            hint.active = true;
            fade = inOut(1f, fadeAmnt);
            StartCoroutine(fade);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (fade != null)
            {
                StopCoroutine(fade);
            }
            hint.active = false;
            fade = inOut(-1f, fadeAmnt);
            StartCoroutine(fade);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                scale.value = add;
            }
        }
    }
}
