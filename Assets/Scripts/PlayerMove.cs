using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    GameObject player; 
    [SerializeField]
    Rigidbody2D rb;
    public float speed;
    public float jump;
    public float backspeed = 5;
    // private bool fripX = true;
    private Animator animator;
    GameObject Tp1;
    GameObject Tp2;

    private DateTime time1;
    private DateTime time2;
    DateTime TimeTmp1;
    DateTime TimeTmp2;
    bool flg1;
    bool flg2;

    bool Run = false; //走るアニメーション
    bool Shot = false; //打つアニメーション
    //タイマー取得
    GameObject Timer;
    PanelAndCountDownController panelController;
    // テレポートで移動するとき一旦力を加えない
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Teleport1" || other.gameObject.tag == "Teleport2")
        {
            rb.velocity = Vector3.zero;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Tp1 = GameObject.FindGameObjectWithTag("Teleport1");
        //Tp2 = GameObject.FindGameObjectWithTag("Teleport2");
        Timer = GameObject.Find("PanelAndCountDownManager");
        panelController = Timer.GetComponent<PanelAndCountDownController>();
    }
   
    // Update is called once per frame
    void Update()
    {
        Playermove();

    }

    public void Playermove()
    {
        // 現在時刻から0.5秒先を取得
        time1 = DateTime.Now.AddSeconds(1.0f);
        time2 = DateTime.Now.AddSeconds(2.0f);
        float x = transform.position.x;
        Vector2 move = Vector2.zero;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (panelController.CountDownTime == 0.0F)
        {  
            Run = false;
            Shot= false;
            if (mousePosition.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f); // プレイヤーを左向きにする
                if (Input.GetKey(KeyCode.A))
                {

                    move = new Vector3(-speed, 0, 0) * Time.deltaTime;
                    //animator.Play("Run");
                    Run = true;
                }
                if (Input.GetKey(KeyCode.D))
                {

                    move = new Vector3(speed - backspeed, 0, 0) * Time.deltaTime;
                    //animator.Play("Run");
                    Run = true;
                }
            }
            if (mousePosition.x >= transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); // プレイヤーを右向きにする
                if (Input.GetKey(KeyCode.A))
                {
                    move = new Vector3(-speed + backspeed, 0, 0) * Time.deltaTime;
                    //animator.Play("Run");
                    Run = true;
                }
                if (Input.GetKey(KeyCode.D))
                {

                    move = new Vector3(speed, 0, 0) * Time.deltaTime;
                    //animator.Play("Run");
                    Run= true;
                }
            }
            Vector3 moveDirection = new Vector3(0, 0, 0);
            /*************************************
            if (Input.GetKey(KeyCode.A))
            {
                move = new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {

                move = new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            **************************************/
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                // スペースキーが押され、上下方向の速度がほぼゼロのとき、ジャンプする
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); //上方向に力を加える
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (flg1 == false)
                {
                    flg1 = true;

                    TimeTmp1 = time1;
                    //Shot = true;
                    animator.Play("Shot");
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (flg2 == false)
                {
                    flg2 = true;

                    TimeTmp2 = time2;
                    //Shot = true;
                    animator.Play("Shot");
                }
            }
            if (DateTime.Now > TimeTmp1)
            {
                if (flg1 == true)
                {
                    flg1 = false;
                }

            }
            if (DateTime.Now > TimeTmp2)
            {
                if (flg2 == true)
                {
                    flg2 = false;
                }
            }
            Vector3 v = new Vector3(move.x, move.y, 0);
            transform.position += v;
            rb.AddForce(moveDirection * speed);   
            
            
            animator.SetBool("Run", Run);
            animator.SetBool("Shot", Shot);
        }

    }
}
