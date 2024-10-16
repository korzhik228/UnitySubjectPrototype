using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;     // Точка, откуда будут вылетать пули
    public GameObject bulletPrefab;  // Префаб пули
    public float bulletSpeed = 20f;  // Скорость пули

    void Update()
    {
        // Получаем позицию мыши в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Вращаем игрока в сторону мыши
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // -90 чтобы правильно выровнять спрайт
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetButtonDown("Fire1")) // Обычно это левая кнопка мыши
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Создаем пулю и устанавливаем её позицию и вращение
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed; // Устанавливаем скорость пули в направлении firePoint
    }
}