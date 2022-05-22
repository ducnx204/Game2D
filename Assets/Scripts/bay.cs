using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bay : MonoBehaviour
{
    public GameObject logo;
    public float time = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(logo, transform.position, transform.rotation);
            Destroy(gameObject, time);
        }
    }
}
