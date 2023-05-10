using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTranceform : MonoBehaviour
{
    // �W�����v��
    public float jumpForce = 10f;

    // �ړ����x
    public float moveSpeed = 5f;

    // �d�͉����x
    public float gravity = 20f;

    // �L�����N�^�[�R���g���[���[
    private CharacterController controller;

    // ���x
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        // �L�����N�^�[�R���g���[���[���擾
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // �ړ�
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        Vector3 move = new Vector3(moveX, 0f, 0f);
        controller.Move(move * Time.deltaTime);

        // �W�����v
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = jumpForce;
        }

        // �d��
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}