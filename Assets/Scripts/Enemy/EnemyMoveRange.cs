using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRange : MonoBehaviour
{
    private Transform target;

    public float speed;
    public float maxDistance;
    public float minDistance;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //movement
        if (Vector2.Distance(transform.position, target.position) > maxDistance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector2 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, target.position) < minDistance)
        {
            Vector2 direction = transform.position - target.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }

    }
}
