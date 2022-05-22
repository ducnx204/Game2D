using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skilboss : MonoBehaviour
{

    public GameObject theboom;
    public Transform shortForm;
    public float shootTime;
    float nextshoot = 0f;
    Animator cannonAnim;

    private void Awake()
    {
        cannonAnim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && Time.time > nextshoot)
        {
            nextshoot = Time.time + shootTime;
            Instantiate(theboom, shortForm.position, Quaternion.identity);
            cannonAnim.SetTrigger("cannnonshort");
        }
    }
}
