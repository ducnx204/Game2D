using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject gamePause;
    public bool isGamePause = false;
    public void GamePause()
    {

    //    AudioManager.instance.StopSound(AudioManager.instance.theme);

        gamePause.SetActive(true);
        isGamePause = true;
        Time.timeScale = 0;
    }

    public void GameResume()
    {

    //    AudioManager.instance.PlaySound(AudioManager.instance.theme, 1);

        gamePause.SetActive(false);
        isGamePause = false;
        Time.timeScale = 1;
    }

}
