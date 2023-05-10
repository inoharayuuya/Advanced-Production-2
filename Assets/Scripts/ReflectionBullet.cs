using UnityEngine;

public class ReflectionBullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    public float cnt = 0;
    private void Start()
    {
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