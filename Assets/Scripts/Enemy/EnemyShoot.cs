using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBulletRedPrefab, enemyBulletBluePrefab;
    public bool color; //true= Red False= Blue


    public float fireRate;
    public float nextFire;    
    private bool canShoot = true;

    void Start()
    {
        fireRate = 1f;
    }


    void Update()
    {
        if (canShoot == true)
        {
            checkIfTimeToFire();
        }
    }

    private void checkIfTimeToFire()
    {
        if (color == true)
        {
            Instantiate(enemyBulletRedPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            canShoot = false;
        }
        if (color == false)
        {
            Instantiate(enemyBulletBluePrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            canShoot = false;
        }
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() //Wait for seconds to shoot again
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

}
