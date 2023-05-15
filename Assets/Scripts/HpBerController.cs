using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBerController : MonoBehaviour
{
    // private
    [SerializeField] private int p1_hp = 100;
    [SerializeField] private int p2_hp = 100;
    [SerializeField] Slider p1_slider;
    [SerializeField] Slider p2_slider;
    [SerializeField] DateTime time;
    DateTime TimeTmp;
    bool flg = false;

    // Update is called once per frame
    void Update()
    {
        // ���ݎ�������0.5�b����擾
        time = DateTime.Now.AddSeconds(0.5);

        // slider�Ɍ��݂̒l����
        p1_slider.value = p1_hp;
        p2_slider.value = p2_hp;

        // �N�[���^�C�����������
        if (flg == false)
        {
            flg = true;

            TimeTmp = time;

            // �v���C���[��HP���c���Ă���ꍇ
            if (p1_hp > 0 && p1_hp > 0)
            {
                p1_hp -= 10;
                p2_hp -= 10;
            }
        }

        // �N�[���^�C���̎��ԂƔ�r���A���ݎ����̕����傫��������
        if(DateTime.Now > TimeTmp)
        {
            flg = false;
        }
    }
}
