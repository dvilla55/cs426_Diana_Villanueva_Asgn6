using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float currHealth;
    public float maxHealth;
    public Slider slider;
    public GameObject healthBarUI;
    Damage dmgTaken;


    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        slider.value = CalculateHealth();
        healthBarUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();

        if (currHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }
    }

    public float CalculateHealth()
    {
        return currHealth / maxHealth;
    }
  private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag=="bullet")
        {
            damageTaken(30);

        }
    }
    public void damageTaken(float damage)
    {
        currHealth -= damage;
    }

  

    
}
