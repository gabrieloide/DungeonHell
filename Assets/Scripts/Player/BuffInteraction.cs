using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffInteraction : MonoBehaviour
{
    public float speedBuff;
    public float fireRateBuff;
    public float timeBuff;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BuffHealth"))
        {
            if (gameObject.GetComponent<PlayerLife>().healthAmount < 10)
                gameObject.GetComponent<PlayerLife>().healthAmount += 2;

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BuffAtackSpeed"))
        {
            StartCoroutine(buffAtackSpeedUp());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BuffSpeed"))
        {
            StartCoroutine(buffSpeedUp());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator buffSpeedUp()
    {
        gameObject.GetComponent<PlayerMovement>().speed += speedBuff;
        yield return new WaitForSeconds(timeBuff);
        gameObject.GetComponent<PlayerMovement>().speed -= speedBuff;
    }

    IEnumerator buffAtackSpeedUp()
    {
        gameObject.GetComponent<PlayerMovement>().Weapon.GetComponent<PlayerShooting>().fireRate += fireRateBuff;
        yield return new WaitForSeconds(timeBuff);
        gameObject.GetComponent<PlayerMovement>().Weapon.GetComponent<PlayerShooting>().fireRate -= fireRateBuff;
    }
}
