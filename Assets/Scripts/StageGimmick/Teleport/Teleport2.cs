using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleport2 : MonoBehaviour
{
    GameObject Player1;
    GameObject Player2;
    GameObject Tp1;
    GameObject Tp2;

    CoolTime script_cooltime;

    float radian;

    // プレイヤーがTp2に触れたらTp1にテレポートする
    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.tag == "Player" && script_cooltime.cnt == 0)
        {
            Player1.transform.position = Tp1.transform.position;
            Debug.Log("プレイヤー１、Tp1に触れました");

            script_cooltime.cooltimetmp = script_cooltime.cooltime;
            script_cooltime.cnt++;

        }

        if (other.gameObject.tag == "Player2" && script_cooltime.cnt == 0)
        {
            Player2.transform.position = Tp1.transform.position;
            Debug.Log("プレイヤー2、Tp1に触れました");

            script_cooltime.cooltimetmp = script_cooltime.cooltime;
            script_cooltime.cnt++;

        }

        


    }




    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        Tp1 = GameObject.FindGameObjectWithTag("Teleport1");
        Tp2 = GameObject.FindGameObjectWithTag("Teleport2");

        script_cooltime = GameObject.Find("CoolTimeManager").GetComponent<CoolTime>();

    }

    // Update is called once per frame
    void Update()
    {
        radian += 0.05f;
        transform.rotation = Quaternion.Euler(0f, 0f, radian);

        if (DateTime.Now > script_cooltime.cooltimetmp)
        {
            script_cooltime.cnt = 0;
        }

    }
}