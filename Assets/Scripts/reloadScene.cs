using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
    public void ReloadScene()
    {
        if (gameController.instance.isGameOver)
        {
            Time.timeScale = 1;
            gameController.instance.isGameOver = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
