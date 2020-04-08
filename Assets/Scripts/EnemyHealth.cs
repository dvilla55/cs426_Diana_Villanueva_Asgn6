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


    [SerializeField] private GameObject body;
    MeshRenderer meshRenderer;
    public Material matFlash;
    Material matDefault;
    Light light;


    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        slider.value = CalculateHealth();
        healthBarUI.SetActive(true);

        meshRenderer = body.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;
        matDefault = meshRenderer.material;
        light = body.AddComponent<Light>();
        light.enabled = false;
        light.color = Color.red;
        light.type = LightType.Point;
        light.range = 5;
        light.intensity = 10;
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
            gameObject.GetComponent<EnemyController>().drop();
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

        meshRenderer.material = matFlash;
        light.enabled = true;
        Invoke("ResetMaterial", 0.1f);
    }

    public void ResetMaterial()
    {
        meshRenderer.material = matDefault;
        light.enabled = false;
    }

    
}
