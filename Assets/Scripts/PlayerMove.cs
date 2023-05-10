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

        Vector3 moveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            // スペースキーが押され、上下方向の速度がほぼゼロのとき、ジャンプする
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); //上方向に力を加える
        }
        rb.AddForce(moveDirection * speed);

    }
}
