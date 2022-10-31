using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtack0 : MonoBehaviour
{
    public GameObject bul;
    public GameObject target;
    public float fireRate;
    private bool canShoot;

    void Start()
    {
        canShoot = false;
        Invoke("Fire", 0);
    }

    void Update()
    {
        if (canShoot)
        {
            Fire();
        }
    }

    public void Fire()
    {
        Vector3 bulMoveVector = new Vector3(target.transform.position.x, target.transform.position.y, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        bul.GetComponent<BossBullet>().setMoveDirection(bulDir);
        Instantiate(bul, transform.position, Quaternion.identity);

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() //Wait for seconds to shoot again
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
