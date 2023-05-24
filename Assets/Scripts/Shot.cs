using System;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursor; //カーソル
    public GameObject bulletPrefab;//反射する弾
    public GameObject bulletPrefab2;//追尾する弾
    public float bulletSpeed = 10f;
    public float offsetDistance = 0.5f;//弾が出る位置の設定
    private DateTime time1;
    private DateTime time2;
    DateTime TimeTmp;
    bool flg1;
    bool flg2;
    //タイマー取得
    GameObject Timer;
    PanelAndCountDownController panelController;
    private void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
        Timer = GameObject.Find("PanelAndCountDownManager");
        panelController = Timer.GetComponent<PanelAndCountDownController>();
    }
    void Update()
    {
        // 現在時刻から0.5秒先を取得
        time1 = DateTime.Now.AddSeconds(1.0f);
        time2 = DateTime.Now.AddSeconds(2.0f);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (panelController.CountDownTime == 0.0F)
        {
            if (mousePosition.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f); // プレイヤーを左向きにする
            }
            if (mousePosition.x >= transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); // プレイヤーを右向きにする
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (flg1 == false)
                {
                    flg1 = true;

                    TimeTmp = time1;
                    Vector2 direction = (mousePosition - (transform.position + transform.up * offsetDistance)).normalized;
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.right * offsetDistance, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (flg2 == false)
                {
                    flg2 = true;

                    TimeTmp = time2;
                    Vector2 direction = (mousePosition - (transform.position + transform.up * offsetDistance)).normalized;
                    GameObject bullet = Instantiate(bulletPrefab2, transform.position + transform.right * offsetDistance, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                }
            }
            if (DateTime.Now > TimeTmp)
            {
                flg1 = false;
                flg2 = false;
            }
        }
    }
}
