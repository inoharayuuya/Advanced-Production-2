using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursor;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public float bulletSpeed = 10f;
    public float offsetDistance = 0.5f;
    public float maxBullet = 1;
    private void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            Vector2 direction = (mousePosition - (transform.position + transform.up * offsetDistance)).normalized;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.right * offsetDistance, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 direction = (mousePosition - (transform.position + transform.up * offsetDistance)).normalized;
            GameObject bullet = Instantiate(bulletPrefab2, transform.position + transform.right * offsetDistance, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
