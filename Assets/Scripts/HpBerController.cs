using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBerController : MonoBehaviour
{
    #region  �v���C�x�[�g
    // private
    [SerializeField] Slider p1_slider;
    [SerializeField] Slider p2_slider;
    [SerializeField] DateTime time;
    DateTime TimeTmp;
    bool flg;

    int g_p1_hp,  // �Q�[�����Ŏg���v���C���[1��hp�ϐ�
        g_p2_hp;  // �Q�[�����Ŏg���v���C���[2��hp�ϐ�
    #endregion

    #region  �p�u���b�N
    // public
    [SerializeField] public int p1_hp = 100;
    [SerializeField] public int p2_hp = 100;
    #endregion

    #region  Init�֐�
    /// <summary>
    /// �������̊֐�
    /// </summary>
    void Init()
    {
        // �v���C���[�ϐ�
        g_p1_hp = p1_hp;  // �v���C���[1hp�̎擾
        g_p2_hp = p2_hp;  // �v���C���[2hp�̎擾

        // �J�E���g�_�E���Ɏg���t���O
        flg = false;
    }
    #endregion

    #region  GetCoolTime�֐�
    /// <summary>
    /// �N�[���^�C���p�̎��Ԃ��擾����֐�
    /// </summary>
    void GetCoolTime()
    {
        // ���ݎ�������0.5�b����擾
        time = DateTime.Now.AddSeconds(0.5);
    }
    #endregion

    #region  SetSliderValue�֐�
    /// <summary>
    /// �X���C�_�[�ɐ��l���Z�b�g����֐�
    /// </summary>
    void SetSliderValue()
    {
        // slider�Ɍ��݂̒l����
        p1_slider.value = p1_hp;
        p2_slider.value = p2_hp;
    }
    #endregion

    #region  CoolTime�֐�
    /// <summary>
    /// �N�[���^�C���̏���
    /// </summary>
    void CoolTime()
    {
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
        if (DateTime.Now > TimeTmp)
        {
            flg = false;
        }
    }
    #endregion

    #region  Start�֐�
    void Start()
    {
        // �ϐ��̏�����
        Init();
    }
    #endregion

    #region  Update�֐�
    // Update is called once per frame
    void Update()
    {
        // �N�[���^�C���̎擾
        GetCoolTime();

        // �X���C�_�[�ɐ��l���Z�b�g
        SetSliderValue();

        // �N�[���^�C���ł��鏈��
        CoolTime();
    }
    #endregion
}
