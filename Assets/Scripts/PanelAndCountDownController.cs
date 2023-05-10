using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class PanelAndCountDownController : MonoBehaviour
{
    [SerializeField] float CountDownTime = 5;
    public TextMeshProUGUI TextCountDown; // �\���p�e�L�X�gUI

    [SerializeField] GameObject CountPanel;
    [SerializeField] GameObject GamePanel;

    // Start is called before the first frame update
    void Start()
    {
        CountPanel.SetActive(true);
        GamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���^�C���𐮌`���ĕ\��
        TextCountDown.text = String.Format("{0:0}", CountDownTime);
        // �o�ߎ����������Ă���
        CountDownTime -= Time.deltaTime;
        
        // 0.0�b�ȉ��ɂȂ�����J�E���g�_�E���^�C����0.0�ŌŒ�i�~�܂����悤�Ɍ�����j
        if (CountDownTime < 0.0F)
        {
            CountDownTime = 0.0F;
            CountPanel.SetActive(false);
            GamePanel.SetActive(true);
        }
    }
}
