using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamaeFloor : MonoBehaviour
{
    GameObject playerClass;
    PlayerClass player;

    // �_���[�W���ɐG��Ă���Ƃ���HP�����炷
    void OnCollisionEnter2D(Collision2D other)
    {
        // �v���C���[�P���G��Ă���Ƃ�
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("�v���C���[�P�A�_���[�W���ɐG��܂���");
            player.g_p1_hp -= 10;
            Debug.Log(player.g_p1_hp);
            //Destroy(other.gameObject);
        }

        // �v���C���[�Q���G��Ă���Ƃ�
        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("�v���C���[�Q�A�_���[�W���ɐG��܂���");
            player.g_p2_hp -= 10;
            Debug.Log(player.g_p2_hp);
            //Destroy(other.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        playerClass = GameObject.Find("PlayerClass");
        player = playerClass.GetComponent<PlayerClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
