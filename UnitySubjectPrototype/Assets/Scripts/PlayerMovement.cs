using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость передвижения игрока
    public int health = 100;      // Здоровье игрока
    public HealthBar healthBar;   // Ссылка на HealthBar UI

    private Vector2 movement; // Вектор направления движения

    void Start()
    {
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Нормализуем вектор движения, чтобы избежать ускорения при диагональном движении
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
    }

    void FixedUpdate()
    {
        // Перемещаем игрока
        Vector2 newPosition = (Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime;
        transform.position = newPosition;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        // Изменение цвета игрока
        StartCoroutine(FlashRed());

        if (health <= 0)
        {
            RestartLevel();
        }
    }

    private IEnumerator FlashRed()
    {
        // Изменяем цвет игрока на красный
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}