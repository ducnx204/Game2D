using UnityEngine;

public class playerControl : MonoBehaviour
{
    // khai bao bien
    public float speed;
    public float jumpHeight;
    public float hoiSkill = 0.5f; // 0.5s bắn 1 lần
    public float nextSkill = 0; // bắn ngay lập tức
    public float hoiSkill_W; // 
    public float nextSkill_W; //
    public float hoiSkill_E; // 
    public float nextSkill_E; //
    //===================================//
    bool facingRight;
    bool isGround;

    // Ám khí Shuriken
    public Transform ShurikenTip;
    public GameObject shuriken;
    // skil w

    public Transform Skil_w;
    public GameObject boom;


    Rigidbody2D myBody;
    Animator myAnim;
    public AudioSource audio;
    public AudioClip JUM;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;

        //AudioManager.instance.PlaySound(AudioManager.instance.theme, 1, true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal"); //di chuyển theo chiều ngang
        myBody.velocity = new Vector2(move * speed, myBody.velocity.y);
        // quay mặt khi di chuyển
        if(move > 0 && !facingRight) //khi đi qua phải và mặc bên trái thì quay mặt
        {
            flip();
        }else if (move < 0 && facingRight) // khi đi qua trái và mặt bên phải thì quay mặt
        {
            flip();
        }

        // chạy
        myAnim.SetFloat("running", Mathf.Abs(move));
    //   myAnim.SetBool("running",true);
  

        Jump();

        Jump_Run(move);

        // Phóng phi tiêu
        ThrowShuriken();
        // skil 2
        ThrowShuriken_W();
    }

    // nhảy
    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myAnim.SetBool("jump", true);
            if (isGround)
            {
                //AudioManager.instance.PlaySound(AudioManager.instance.jump, 1);
                if (audio && JUM)
                {
                    audio.PlayOneShot(JUM);
                }
                isGround = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
            }
        }
        else myAnim.SetBool("jump", false);

    }
    void Jump_Run(float move)
    {
        if(Input.GetKey(KeyCode.UpArrow) && (move>0 || move <0))
        {
         //   myAnim.SetBool("run&jump", true);
            if (isGround)
            {
                //AudioManager.instance.PlaySound(AudioManager.instance.jump, 1);

                isGround = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
            }
        }
      //  else myAnim.SetBool("run&jump", false);
    }
    // quay mặt
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // xử lí va chạm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "Obstacles")
        {
            //AudioManager.instance.PlaySound(AudioManager.instance.die, 1);

            gameObject.SetActive(false);

            gameController.instance.GameOver();

            Time.timeScale = 0;
        }
    }

    // ném phi tiêu
    void ThrowShuriken()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            myAnim.SetBool("attackShuriken", true);
            if (Time.time > nextSkill)
            {
                nextSkill = Time.time + hoiSkill;
                if (facingRight)
                {
                    Instantiate(shuriken, ShurikenTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }else if (!facingRight)
                {
                    Instantiate(shuriken, ShurikenTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
            }

        }else myAnim.SetBool("attackShuriken", false);
    }

    // chuong bom 20s skil w

    void ThrowShuriken_W()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myAnim.SetBool("attackShuriken", true);
            if (Time.time > nextSkill_W)
            {
                nextSkill_W = Time.time + hoiSkill_W;
                if (facingRight)
                {
                    Instantiate(boom, ShurikenTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else if (!facingRight)
                {
                    Instantiate(boom, ShurikenTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
            }
            return;

        }
        else myAnim.SetBool("attackShuriken", false);
    }
}
