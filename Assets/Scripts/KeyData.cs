using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyData : MonoBehaviour
{
    [SerializeField] private int type;
    [SerializeField] private InventoryManager access;

    private void Start()
    {
        access = GameObject.Find("Player").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            access.updateIn(type);
            Destroy(gameObject);
        }
    }

}
