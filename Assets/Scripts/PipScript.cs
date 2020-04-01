using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipScript : MonoBehaviour
{
    public int add;
    public Slider scale;

    private void OnTriggerEnter(Collider other)
    {
        scale.value += add;
        Destroy(gameObject);
    }
}
