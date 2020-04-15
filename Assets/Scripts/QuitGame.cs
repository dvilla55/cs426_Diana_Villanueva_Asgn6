using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button quitGame;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = quitGame.GetComponent<Button>();
        btn.onClick.AddListener(exit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exit()
    {
        Application.Quit();
    }
}
