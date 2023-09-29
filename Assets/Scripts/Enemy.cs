using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private static int maxLife = 100;

    public float speed;
    private Transform target;
    private int currentWaypoint;
    public float turnSpeed;
    [SerializeField]
    private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = maxLife;
        target = Waypoint.points[0];
        this.currentWaypoint = 0;
        this.turnSpeed = 100f;
        this.speed = 1.0f;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        if (direction.magnitude < 0.05)
        {
            if (currentWaypoint == Waypoint.points.Length - 1)
            {
                GameManager.Instance.playerLoseLife(10);
                Destroy(gameObject);
            }
            else
            {
                currentWaypoint += 1;
                target = Waypoint.points[currentWaypoint];
                direction = target.position - transform.position;
            }

        }

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
        GameManager.Instance.playerIncreaseScore(10);

    }

}
