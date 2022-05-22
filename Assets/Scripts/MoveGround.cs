using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float speed = -2;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity =
            new Vector2(0, transform.localScale.y) * speed;
        
    }

}
