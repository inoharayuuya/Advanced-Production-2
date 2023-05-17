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
    // private bool fripX = true;

    GameObject Tp1;
    GameObject Tp2;

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


        Tp1 = GameObject.FindGameObjectWithTag("Teleport1");
        Tp2 = GameObject.FindGameObjectWithTag("Teleport2");
    }
   
    // Update is called once per frame
    void Update()
    {
        Playermove();

    }

    public void Playermove()
    {
        float x = transform.position.x;
        Vector2 move = Vector2.zero;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // プレイヤーを左向きにする
        }
        if (mousePosition.x >= transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // プレイヤーを右向きにする
        }
        Vector3 moveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            move = new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move = new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            // スペースキーが押され、上下方向の速度がほぼゼロのとき、ジャンプする
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); //上方向に力を加える
        }
        Vector3 v = new Vector3(move.x, move.y, 0);
        transform.position += v;
        rb.AddForce(moveDirection * speed);

    }
}
