using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTranceform : MonoBehaviour
{
    // ジャンプ力
    public float jumpForce = 10f;

    // 移動速度
    public float moveSpeed = 5f;

    // 重力加速度
    public float gravity = 20f;

    // キャラクターコントローラー
    private CharacterController controller;

    // 速度
    private Vector3 velocity = Vector3.zero;

    //タイマー取得

    GameObject Timer;
    PanelAndCountDownController panelController;
    void Start()
    {
        // キャラクターコントローラーを取得
        controller = GetComponent<CharacterController>();
        Timer = GameObject.Find("PanelAndCountDownManager");
        panelController = Timer.GetComponent<PanelAndCountDownController>();
    }

    void Update()
    {
        if (panelController.CountDownTime == 0.0F)
        {
            // 移動
            float moveX = Input.GetAxis("Horizontal") * moveSpeed;
             Vector3 move = new Vector3(moveX, 0f, 0f);
             controller.Move(move * Time.deltaTime);

            // ジャンプ
             if (Input.GetButtonDown("Jump") && controller.isGrounded)
             {
                velocity.y = jumpForce;
             }

        }

        // 重力
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}