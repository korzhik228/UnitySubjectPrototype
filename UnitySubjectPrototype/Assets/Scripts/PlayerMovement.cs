using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public int health = 100;    
    public HealthBar healthBar; 

    private Vector2 movement; 

    void Start()
    {
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
       
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");


        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
    }

    void FixedUpdate()
    {
        Vector2 newPosition = (Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime;
        transform.position = newPosition;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        StartCoroutine(FlashRed());

        if (health <= 0)
        {
            RestartLevel();
        }
    }

    private IEnumerator FlashRed()
    {
       
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