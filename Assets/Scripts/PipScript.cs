using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipScript : MonoBehaviour
{
    public int add;
    public Slider scale;
    AudioSource sound;
    Vector3 startingPosition;
    int direction = -1;
    void Start()
    {
        startingPosition = transform.position;
        sound = gameObject.AddComponent<AudioSource>();
        sound.clip = Resources.Load<AudioClip>("Audio/item_pickup");
        if(gameObject.name == "New Pip")
        {
            sound.pitch = 0.8f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            scale.value += add;
            sound.Play();
            transform.position = new Vector3(0, 0, 0);
            Destroy(gameObject, 3);
        }
    }

    private void Update()
    {
        if (direction == -1 && startingPosition.y - 1f>= transform.position.y)
        {
            direction = 1;
        }
        else if (direction == 1 && startingPosition.y <= transform.position.y)
        {
            direction = -1;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f * Time.deltaTime * direction, transform.position.z);
        transform.Rotate(0,  50 * Time.deltaTime,0);
    }
}
