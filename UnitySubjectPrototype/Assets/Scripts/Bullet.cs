using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;   // Время жизни пули
    public int damage = 10;        // Урон пули

    void Start()
    {
        // Уничтожаем пулю через заданное время
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, попали ли мы в врага
        EnemyAI enemy = collision.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Наносим урон врагу
        }

        // Уничтожаем пулю при столкновении
        Destroy(gameObject);
    }
}