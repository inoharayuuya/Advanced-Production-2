using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class DamaeFloor : StrixBehaviour
{
    GameObject playerClass;
    PlayerClass player;

    // ダメージ床に触れているときにHPを減らす
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            // プレイヤー１が触れているとき
            if (StrixNetwork.instance.playerName == "Player1")
            {
                Debug.Log("プレイヤー１、ダメージ床に触れました");
                player.g_p1_hp -= 10;
                Debug.Log(player.g_p1_hp);
                //Destroy(other.gameObject);
            }
            
            // プレイヤー２が触れているとき
            if (StrixNetwork.instance.playerName == "Player2")
            {
                Debug.Log("プレイヤー２、ダメージ床に触れました");
                player.g_p2_hp -= 10;
                Debug.Log(player.g_p2_hp);
                //Destroy(other.gameObject);
            }
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
