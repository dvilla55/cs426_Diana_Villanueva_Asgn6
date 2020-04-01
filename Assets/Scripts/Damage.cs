using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    PhaseSystem phase;
    EnemyHealth enemyHealth;

    public float takeDamage()
    {
        switch(phase.getPhase())
        {
                case 0:
                return 20;

                case 3:
                return 50;

                default:
                return 10;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Enemy")
        {

            Debug.Log("Collision Detected");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
