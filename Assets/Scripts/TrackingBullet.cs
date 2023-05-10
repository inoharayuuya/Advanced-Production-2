using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] private Transform tirgetTrans; //追いかける対象のTransform
    [SerializeField] private float bulletSpeed;  　 //弾の速度
    [SerializeField] private float limitSpeed;      //弾の制限速度
    private Rigidbody2D rb;                         //弾のRigidbody2D
    private Transform bulletTrans;                  //弾のTransform
    public float speed = 10f;
    float elapsedTime = 0f; // 経過時間のカウント変数
    public float delayTime = 1f;   // 遅延時間（1秒）

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletTrans = GetComponent<Transform>();
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime; // 経過時間をカウント
        if (elapsedTime >= delayTime)
        {
            if (tirgetTrans != null)
            {
                Vector3 vector3 = tirgetTrans.position - bulletTrans.position;  //弾から追いかける対象への方向を計算
                rb.AddForce(vector3.normalized * bulletSpeed);                  //方向の長さを1に正規化、任意の力をAddForceで加える

                float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed); //X方向の速度を制限
                float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);  //Y方向の速度を制限
                rb.velocity = new Vector3(speedXTemp, speedYTemp);

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player2")
        {
            // オブジェクトを削除
            Destroy(bullet);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(bullet);
        }
    }
}
