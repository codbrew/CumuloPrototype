using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject levelOneComplete;
    bool gameHasEnded = false;
    public float restartDelay = 0.5f;

    public void CompleteLevel()
    {
        levelOneComplete.SetActive(true);
    }

   public void EndGame()
    {
        if (gameHasEnded == false)
        {

            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
