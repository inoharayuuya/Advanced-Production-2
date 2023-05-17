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
        // 現在時刻から0.5秒先を取得
        time = DateTime.Now.AddSeconds(0.5);

        // sliderに現在の値を代入
        p1_slider.value = p1_hp;
        p2_slider.value = p2_hp;

        // クールタイムが無ければ
        if (flg == false)
        {
            flg = true;

            TimeTmp = time;

            // プレイヤーのHPが残っている場合
            if (p1_hp > 0 && p1_hp > 0)
            {
                p1_hp -= 10;
                p2_hp -= 10;
            }
        }

        // クールタイムの時間と比較し、現在時刻の方が大きかったら
        if(DateTime.Now > TimeTmp)
        {
            flg = false;
        }
    }
}
