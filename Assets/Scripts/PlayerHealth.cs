using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public Slider healthPlayerSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthPlayerSlider.maxValue = maxHealth;
        healthPlayerSlider.value = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDame(float dame)
    {
        if (dame <= 0) return;

        currentHealth -= dame;
       healthPlayerSlider.value = currentHealth;

        if (currentHealth <= 0)
            gameOver();
    }
    // tao chuc nang hoi mau khi an vien mau
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthPlayerSlider.value = currentHealth;
    }
    void gameOver()
    {
        //AudioManager.instance.PlaySound(AudioManager.instance.die, 1);

        gameObject.SetActive(false);

        gameController.instance.GameOver();

        Time.timeScale = 0;
    }
}
