using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    public Text scoreText;
    
    public Text gameOverScoreText;

    public GameObject gameOver;
    public bool isGameOver = false;

    public AudioSource aus;
    public AudioClip gameover;

    private int score = 0;
    private int score_hienthi = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
    }

    public void AddScore( int score)
    {
        this.score += score;
        scoreText.text = ""+this.score;
    }

    public void GameOver()
    { 
        gameOverScoreText.text = "Score: " + this.score;
        gameOver.SetActive(true);

        if (aus && gameover)
        {
            aus.PlayOneShot(gameover);
        }
        isGameOver = true;
    }
 
    
}
