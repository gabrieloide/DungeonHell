using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float followSpeed;
    public Transform trackingTarget;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    public bool isXLocked, isYLocked;

    private void FixedUpdate()
    {
        float xTarget = trackingTarget.position.x + xOffset;
        float yTarget = trackingTarget.position.y + yOffset;
        float xNew = transform.position.x;
        if (!isXLocked)
        {
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        }

        float yNew = transform.position.y;
        if (!isYLocked)
        {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
        }

        transform.position = new Vector3(xNew, yNew, transform.position.z);

    }
}
