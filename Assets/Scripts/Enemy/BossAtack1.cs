using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtack1 : MonoBehaviour
{
    public GameObject bul;
    public float fireRate;
    public int bulletsAmount;
    private bool canShoot;

    [SerializeField]
    private float startAngle = 90f, endAngle = 290f;

    private Vector2 bulletMoveDirection;

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

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletsAmount ; i++)
        {
            float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

            Vector3 bulMoveVector = new Vector3(bulDirx, bulDiry, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.GetComponent<BossBullet>().setMoveDirection(bulDir);
            Instantiate(bul, transform.position, Quaternion.identity);

            angle += angleStep;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown() //Wait for seconds to shoot again
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
