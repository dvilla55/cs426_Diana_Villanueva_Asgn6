using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float blink;
    public float immuned;
    public float player;
    private Renderer model;
    private float blinkTime = 0.1f;
    private float immunedTime;
    public bool testDamage = false;
    public bool isDead = false;

    public Transform respawnTarget;
    private bool isRespawning;
    private Vector3 respawnLocation;

    GameManager gameRef;
    int life = 2;

    // Start is called before the first frame update
    void Start()
    {

        model = GetComponentInChildren<SkinnedMeshRenderer>();

        respawnLocation = respawnTarget.transform.position;

        gameRef = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (immunedTime >= 0)
        {
            immunedTime -= Time.deltaTime;

            blinkTime -= Time.deltaTime;

            if (blinkTime <= 0)
            {
                model.enabled = !model.enabled;
                blinkTime = blink;
            }
           if (immunedTime <= 0)
           {
            model.enabled = true;
           }
        }
    }

  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).otherCollider.gameObject.tag != "Slash")
        {
            if (collision.gameObject.tag == "Enemy" && immunedTime <= 0)
            {
                print("hit player from playerhealth");
                damagePlayer();
            }
            else if (collision.gameObject.tag == "trap" && immunedTime <= 0)
            {
                print("hit player from playerhealth");
                damagePlayer();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit!");
        Debug.Log(collision.gameObject.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && immunedTime <= 0)
        {
            print("hit player from playerhealth");
            damagePlayer();
        }
    }
    public void damagePlayer()
    {

        if (immunedTime <= 0)
        {
            gameRef.images[life].enabled = false;
            life--;

            if (life < 0)
            {
                //respawn();
                isDead = true;
                gameRef.EndGame();
            }
            else
            {
                immunedTime = immuned;
                model.enabled = false;

                blinkTime = blink;
            }
        }

    }
}
