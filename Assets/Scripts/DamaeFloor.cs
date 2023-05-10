using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamaeFloor : MonoBehaviour
{


    // ダメージ床に触れているときにHPを減らす
    void OnCollisionStay2D(Collision2D other)
    {
        // プレイヤー１が触れているとき
        if(other.gameObject.tag == "Player1")
        {
            Debug.Log("プレイヤー１、ダメージ床に触れています");
            //Destroy(other.gameObject);
        }

        // プレイヤー２が触れているとき
        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("プレイヤー２、ダメージ床に触れています");
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
