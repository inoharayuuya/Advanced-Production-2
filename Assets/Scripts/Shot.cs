using System;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursor; //�J�[�\��
    public GameObject bulletPrefab;//���˂���e
    public GameObject bulletPrefab2;//�ǔ�����e
    public float bulletSpeed = 10f;
    public float offsetDistance = 0.5f;//�e���o��ʒu�̐ݒ�
    private DateTime time;
    DateTime TimeTmp;
    bool flg;
    //�^�C�}�[�擾
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
        // ���ݎ�������0.5�b����擾
        time = DateTime.Now.AddSeconds(1.0f);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (panelController.CountDownTime == 0.0F)
        {
            if (mousePosition.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f); // �v���C���[���������ɂ���
            }
            if (mousePosition.x >= transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); // �v���C���[���E�����ɂ���
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (flg == false)
                {
                    flg = true;

                    TimeTmp = time;
                    Vector2 direction = (mousePosition - (transform.position + transform.up * offsetDistance)).normalized;
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.right * offsetDistance, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (flg == false)
                {
                    flg = true;

                    TimeTmp = time;
                    Vector2 direction = (mousePosition - (transform.position + transform.up * offsetDistance)).normalized;
                    GameObject bullet = Instantiate(bulletPrefab2, transform.position + transform.right * offsetDistance, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                }
            }
            if (DateTime.Now > TimeTmp)
            {
                flg = false;
            }
        }
    }
}
