using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public PlayerMovement PlayerColor;

    public Transform ShootPosition;
    public Projectile projectilePrefabRed, projectilePrefrabBlue;

    Camera cam;
    [Range(0, 30)]
    public float rotationSpeed;

    public float fireRate;
    bool canShoot = true;
    public float damage;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
        transform.up = Vector2.MoveTowards(transform.up, direction, rotationSpeed * Time.deltaTime);
        if (Input.GetMouseButton(0) && canShoot)
        {
            switch (PlayerColor.PlayerCurrentColor)
            {
                case PlayerColorState.PlayerRed:
                    Projectile projectileRed = Instantiate(projectilePrefabRed, ShootPosition.position, transform.rotation);
                   //projectileRed.LaunchProjectile(transform.up);
                    canShoot = false;
                    break;
                case PlayerColorState.PlayerBlue:
                    Projectile projectileBlue = Instantiate(projectilePrefrabBlue, ShootPosition.position, transform.rotation);
                    //projectileBlue.LaunchProjectile(transform.up);
                    canShoot = false;
                    break;
            }
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()//Wait for seconds to shoot again
    {
        yield return new WaitForSeconds(0.5f / fireRate);
        canShoot = true;
    }
}
