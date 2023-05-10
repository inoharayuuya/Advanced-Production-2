using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class HpSliderController : MonoBehaviour
{
    public int hp = 100;
    private int count = 0;
    DateTime coolTime;
    DateTime coolTimeTmp;
    [SerializeField] private float endTime = 0;  // クールタイムの時間を設定
    [SerializeField] UnityEngine.UI.Slider P1_Slider;
    [SerializeField] UnityEngine.UI.Slider P2_Slider;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        P1_Slider.value = 100;
        P2_Slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        coolTime = DateTime.Now.AddSeconds(endTime);    // 現在の時刻からendTime分先を取得する
        if (count == 0)
        {
            // クールタイム開始
            coolTimeTmp = coolTime;
            count++;
            //if(hp > 0)
            //{
            //    hp -= 10;
            //    P1_Slider.value -= 10;
            //    P2_Slider.value -= 10;
            //}
        }

        // クールタイムの設定
        if (DateTime.Now > coolTimeTmp)
        {
            count = 0;
        }
    }
}
