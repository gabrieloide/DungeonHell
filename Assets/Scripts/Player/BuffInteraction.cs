using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffInteraction : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BuffHealth"))
        {
            gameObject.GetComponent<PlayerLife>().healthAmount += 1;
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
        gameObject.GetComponent<PlayerMovement>().speed += 1;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<PlayerMovement>().speed -= 1;
    }

    IEnumerator buffAtackSpeedUp()
    {
        gameObject.GetComponent<PlayerMovement>().Weapon.GetComponent<PlayerShooting>().fireRate += 1;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<PlayerMovement>().Weapon.GetComponent<PlayerShooting>().fireRate -= 1;
    }
}
