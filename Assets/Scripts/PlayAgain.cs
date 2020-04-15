using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{

    public Button playAgain;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = playAgain.GetComponent<Button>();
        btn.onClick.AddListener(clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        FindObjectOfType<GameManager>().Restart();
    }
}
