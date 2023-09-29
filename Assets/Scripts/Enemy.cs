using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Enemy(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.speed = 1.0f;
        this.currentWaypoint = 0;
        this.turnSpeed = 100f;
        this.life = 1000;
        this.currentHealth = this.life;
    }

    public GameManager gameManager;

    public float speed;
    private Transform target;
    private int currentWaypoint;
    public float turnSpeed;
    public int life;
    private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        this.life = 1000;
        this.currentHealth = this.life;
        target = Waypoint.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(1);
        Vector2 direction = target.position - transform.position;
        if (direction.magnitude < 0.05) {
            if (currentWaypoint == Waypoint.points.Length - 1)
            {
                gameManager.playerLoseLife(10);
                Destroy(gameObject);
            }
            else
            {
                currentWaypoint += 1;
                target = Waypoint.points[currentWaypoint];
                direction = target.position - transform.position;
            }

        }

        Vector2 move = direction.normalized * speed * Time.deltaTime;
        Vector3 current = transform.up;
        Vector3 to = target.position - transform.position;
        transform.up = Vector3.RotateTowards(current, to, turnSpeed * Time.deltaTime, 300);
        transform.up = new Vector3(transform.up.x, transform.up.y, 0);
        transform.position += transform.up * speed * Time.deltaTime;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
        gameManager.playerIncreaseScore(10);

    }

}
