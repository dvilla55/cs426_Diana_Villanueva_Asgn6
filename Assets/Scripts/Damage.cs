using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    public PhaseSystem phase;
    EnemyHealth enemyHealth;
    public Slider scale;


    public float takeDamage()
    {
        if(scale.value > 0)
        {
            switch (phase.getPhase())
            {
                case 0:
                    return 20 * (scale.value);

                case 3:
                    return 50 * (scale.value);

                default:
                    return 10 * (scale.value);
            }
        }
        else
        {
            if(phase.getPhase() == 0)
            {
                return 20 * Mathf.Abs(scale.value);
            }
            else
            {
                return 0;
            }
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
