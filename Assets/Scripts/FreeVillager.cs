using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeVillager : MonoBehaviour
{
    public bool isFree;
    float time;
    public Material material;
    Renderer rend;
    AudioSource audio;
    bool isKachujin = false; //imported fbx character 

    // Start is called before the first frame update
    void Start()
    {
        isFree = false;
        rend = GetComponent<Renderer>();

        if (rend == null)
        {
            rend = GetComponentInChildren<Renderer>();
            isKachujin = true;
        }

        rend.enabled = true;
        audio = gameObject.AddComponent<AudioSource>();

        int gender = Random.Range(1, 3); //picks a number to determine the audio played. 1 for male, 2 for female
        
        if (gender == 1 && !isKachujin)
        {
            audio.clip = Resources.Load<AudioClip>("Audio/thank_you_male");
        }
        else{
            audio.clip = Resources.Load<AudioClip>("Audio/thank_you_female");
        }
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
            if (!isFree)
            { //this conditional is so that the audio clip doesnt play twice
                audio.Play();
            }
            isFree = true;
        }
    }
}
