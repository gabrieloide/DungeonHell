using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveMelee : MonoBehaviour
{
    private Transform target;

    public float speed;
    public float stopDistance;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //movement
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
