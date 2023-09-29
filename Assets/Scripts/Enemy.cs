using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;
    private int currentWaypoint = 0;
    public float turnSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoint.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;

        if (direction.magnitude < 0.05) {
            if (currentWaypoint == Waypoint.points.Length - 1)
            {
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
        //Vector2 rotation = Vector3.RotateTowards(transform.rotation, target.position, 1, 1);
        Vector3 current = transform.up;
        Vector3 to = target.position - transform.position;
        transform.up = Vector3.RotateTowards(current, to, turnSpeed * Time.deltaTime, 300);
        transform.up = new Vector3(transform.up.x, transform.up.y, 0);
        //transform.Transla+te(move);
        transform.position += transform.up * speed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x, transform.position.y, -2);
    }
}
