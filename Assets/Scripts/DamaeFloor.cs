using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamaeFloor : MonoBehaviour
{


    // �_���[�W���ɐG��Ă���Ƃ���HP�����炷
    void OnCollisionStay2D(Collision2D other)
    {
        // �v���C���[�P���G��Ă���Ƃ�
        if(other.gameObject.tag == "Player1")
        {
            Debug.Log("�v���C���[�P�A�_���[�W���ɐG��Ă��܂�");
            //Destroy(other.gameObject);
        }

        // �v���C���[�Q���G��Ă���Ƃ�
        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("�v���C���[�Q�A�_���[�W���ɐG��Ă��܂�");
            //Destroy(other.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
