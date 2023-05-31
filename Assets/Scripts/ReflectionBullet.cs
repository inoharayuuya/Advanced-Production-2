using UnityEngine;

public class ReflectionBullet : MonoBehaviour
{
    GameObject playerClass;
    PlayerClass player;
    [SerializeField]
    GameObject bullet;
    public float cnt = 0;
    float elapsedTime = 0f; // 経過時間のカウント変数
    private Rigidbody2D rb;
    private Transform bulletTransform;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletTransform = transform;
        playerClass = GameObject.Find("PlayerClass");
        player = playerClass.GetComponent<PlayerClass>();
    }
    private void Update()
    { 
        elapsedTime += Time.deltaTime; // 経過時間をカウント

        if (elapsedTime >= 4)
        {
            Destroy(bullet);
        }
        Vector2 direction = rb.velocity.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        switch(cnt)
        {
                case 0:
                GetComponent<Renderer>().material.color = Color.blue;
                break;
                case 1:
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
                case 2:
                GetComponent<Renderer>().material.color = Color.red;
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            cnt++;
            //Debug.Log("a");
        }
        if (cnt == 3)
        {
            Destroy(bullet);
        }
        if (collision.gameObject.name == "Player2")
        {
            if(player.g_p2_hp > 0)
            {
                player.g_p2_hp -= player.p1_attack;
            }
            Debug.Log(player.g_p2_hp);
            Destroy(bullet);
        }
    }
}