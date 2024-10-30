using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;   
    public int damage = 10;        

    void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, попали ли мы в врага
        EnemyAI enemy = collision.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); 
        }

       
        Destroy(gameObject);
    }
}