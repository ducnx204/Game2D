using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public Slider enemyHealthSlider;

    // Tao h.u khi enyme chet;
    public GameObject enemyDead;
    // kb bien de khi cac enmy chet  se roi ra vien mau hoac cois
    public bool drop;

    public GameObject theDrop;
    // kb bien de khi cac enmy chet  se roi ra vien mau hoac cois
    void Start()
    {
        currentHealth = maxHealth;

        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDame(float dame)
    {
        enemyHealthSlider.gameObject.SetActive(true);

        currentHealth -= dame;
        enemyHealthSlider.value = currentHealth;
        
        if(currentHealth <= 0)
        {
            makeDead();
        }
    }
    void makeDead()
    {
        Destroy(gameObject);
        gameObject.SetActive(false);
        Instantiate(enemyDead, transform.position, transform.rotation);
        // chuc nang roi ra vien mau hoặc cois
        if (drop)
        {
            mau_and_vang();
        }
    

    }
    void mau_and_vang()
    {
        Instantiate(theDrop, transform.position, transform.rotation);
       
    }
}
