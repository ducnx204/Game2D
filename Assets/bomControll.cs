using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomControll : MonoBehaviour
{
    public float bomSpeedHight;
    public float boomSpeedLow;
    public float bomAngle;

    Rigidbody2D cannonRB;

    private void Awake()
    {
        cannonRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        cannonRB.AddForce(new Vector2(Random.Range(-bomAngle, bomAngle), Random.Range(boomSpeedLow, bomSpeedHight)),
            ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
