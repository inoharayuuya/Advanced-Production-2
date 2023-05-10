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
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // �v���C���[���������ɂ���
        }
        if (mousePosition.x >= transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // �v���C���[���E�����ɂ���
        }
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
            // �X�y�[�X�L�[��������A�㉺�����̑��x���قڃ[���̂Ƃ��A�W�����v����
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); //������ɗ͂�������
        }
        rb.AddForce(moveDirection * speed);

    }
}
