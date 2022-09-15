using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float CameraSpeed;

    private void LateUpdate()
    {
        Vector3 PlayerTarget = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerTarget, CameraSpeed * Time.deltaTime);
    }
}
