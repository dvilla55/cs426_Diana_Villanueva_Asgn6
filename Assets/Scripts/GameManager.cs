using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public Transform gameOverUI;
    public Transform credits;
    public RawImage[] images = new RawImage[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");

            if (!gameOverUI.gameObject.activeInHierarchy)
            {
                gameOverUI.gameObject.SetActive(true);
                gameOverUI.GetComponent<Animator>().enabled = true;
               


            }
            else
            {
                gameOverUI.gameObject.SetActive(false); //should be false?
            }

            AudioListener.pause = true;
            //Time.timeScale = 0;
        }
    }
    public IEnumerator YieldThenPerform() { yield return new WaitForSeconds(21f); Application.Quit(); }
   
    public void rollCredits()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (credits != null)
        {
            credits.gameObject.SetActive(true);
            //Animator creditScroll = credits.GetComponentInChildren<Animator>();
        }
    }
   

    public void Restart()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
