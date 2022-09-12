using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public Transform target;
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transitionfinished();
    }

    public async void transitionfinished()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
        await Task.Yield();
        Debug.Log("next task");
    }
}
