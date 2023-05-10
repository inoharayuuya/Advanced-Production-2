using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class PanelAndCountDownController : MonoBehaviour
{
    [SerializeField] float CountDownTime = 5;
    public TextMeshProUGUI TextCountDown; // 表示用テキストUI

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
        // カウントダウンタイムを整形して表示
        TextCountDown.text = String.Format("{0:0}", CountDownTime);
        // 経過時刻を引いていく
        CountDownTime -= Time.deltaTime;
        
        // 0.0秒以下になったらカウントダウンタイムを0.0で固定（止まったように見せる）
        if (CountDownTime < 0.0F)
        {
            CountDownTime = 0.0F;
            CountPanel.SetActive(false);
            GamePanel.SetActive(true);
        }
    }
}
