using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int coinValue = 1;

    public AudioSource aus;
    public AudioClip coiSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            gameController.instance.AddScore(coinValue);
            if (aus && coiSound)
            {
                aus.PlayOneShot(coiSound);
            }
            Destroy(gameObject);
        }

      
    }

 
}
