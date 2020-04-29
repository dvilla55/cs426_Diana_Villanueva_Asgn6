using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeTrigger : MonoBehaviour
{
    public bool destroyBullet = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Edge Hit!");
            other.gameObject.GetComponent<EnemyController>().direction = (other.gameObject.GetComponent<EnemyController>().direction + 1) % 2;
        }

        if(other.gameObject.tag == "Bullet" && destroyBullet)
        {
            Destroy(other.gameObject);
        }
    }
}
