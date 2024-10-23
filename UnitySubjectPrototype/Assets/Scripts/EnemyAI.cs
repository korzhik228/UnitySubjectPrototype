using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 5f;  // Радиус обнаружения игрока
    public float moveSpeed = 3f;        // Скорость передвижения врага
    public int health = 100;             // Здоровье врага
    public int damage = 30;              // Урон врага

    private Transform player;            // Ссылка на игрока
    private bool isPlayerInRange = false; // Флаг, указывающий, находится ли игрок в зоне обнаружения

    void Start()
    {
        GameObject playerObject = GameObject.Find("Player"); // Предполагается, что игрок называется "Player"
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            isPlayerInRange = distanceToPlayer <= detectionRange;

            if (isPlayerInRange)
            {
                ChasePlayer();
            }
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Уничтожаем врага, если здоровье меньше или равно нулю
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}