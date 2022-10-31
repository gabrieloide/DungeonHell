using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtack2 : MonoBehaviour
{
    public GameObject bul;
    public float fireRate;
    public float spiralNumber;
    public float angleDiference;
    private bool canShoot;

    private float angle = 0f;
    private Vector2 bulletMovemeDirection;

    void Start()
    {
        Invoke("Fire", 0); 
    }

    private void Update()
    {
        if (canShoot)
        {
            Fire();
        }
    }

    public void Fire()
    {
        for(int i = 0; i < spiralNumber; i++)
        {
            float bulDirx = transform.position.x + Mathf.Sin(((angle + 360/spiralNumber * i) * Mathf.PI) / 180f);
            float bulDiry = transform.position.y + Mathf.Cos(((angle + 360/spiralNumber * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirx, bulDiry, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.GetComponent<BossBullet>().setMoveDirection(bulDir);
            Instantiate(bul, transform.position, Quaternion.identity);
        }

        angle += angleDiference;
        if (angle%360 == 0)
        {
            angle = 0f;
        }

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() //Wait for seconds to shoot again
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
