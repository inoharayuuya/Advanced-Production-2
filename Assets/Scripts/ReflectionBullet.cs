using UnityEngine;

public class ReflectionBullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    public float cnt = 0;
    float elapsedTime = 0f; // �o�ߎ��Ԃ̃J�E���g�ϐ�
    private void Start()
    {
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime; // �o�ߎ��Ԃ��J�E���g

        if (elapsedTime >= 4)
        {
            Destroy(bullet);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            cnt++;
            Debug.Log("a");
        }
        if (cnt == 3)
        {
            Destroy(bullet);
        }
        if (collision.gameObject.name == "Player2")
        {
            Destroy(bullet);
        }
    }
}