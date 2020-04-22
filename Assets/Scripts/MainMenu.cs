using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public string[] text;
    int index = 0;
    public TextMeshProUGUI display;
    public TextMeshProUGUI op;

    public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void next()
    {
        if(index != 3)
        {
            if(index == 2)
            {
                op.text = "P  L  A  Y";
            }
            display.text = text[index];
            index++;
        }
        else
        {
            index = 0;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
