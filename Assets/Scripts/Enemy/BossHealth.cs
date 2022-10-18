using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float healthAmount;
    public bool canTakeDamage;
    public Color colorAlpha;
    public GameObject healthBar;
    private Vector2 scaleBar, positionBar;
    public GameObject[] EnemyPrefabs;


    void Start()
    {
        healthAmount = 15;
        canTakeDamage = true;
        colorAlpha = gameObject.GetComponent<SpriteRenderer>().color;

        scaleBar.x = 15f;
        scaleBar.y = 0.5f;
        positionBar.y = -4.5f;
    }

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorAlpha;

        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }

        healthBar.transform.localScale = scaleBar;
        healthBar.transform.localPosition = positionBar;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canTakeDamage)
        {
            healthAmount -= 1f;
            scaleBar.x -= 1f;
            positionBar.x -= 0.5f;
            StartCoroutine(takeDamage());

            if (healthAmount == 12)
            {
                wave1(5);
            }
            if (healthAmount == 8)
            {
                wave2(7);
            }
            if (healthAmount == 6)
            {
                wave3(9);
            }
            if (healthAmount == 3)
            {
                wave4(12);
            }
        }
    }


    private void wave1(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnAenemy(EnemyPrefabs[UnityEngine.Random.Range(0, 6)]);
        }
    }
    private void wave2(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnAenemy(EnemyPrefabs[UnityEngine.Random.Range(0, 6)]);
        }
    }

    private void wave3(int numEnemies)
    {
        for(int i = 0; i < numEnemies; i++)
        {
            SpawnAenemy(EnemyPrefabs[UnityEngine.Random.Range(0, 6)]);
        }
    }

    private void wave4(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnAenemy(EnemyPrefabs[UnityEngine.Random.Range(0, 6)]);
        }
    }

    private void SpawnAenemy(GameObject enemy)
    {
        Debug.Log("Enemy Has spawned");
        Instantiate(enemy, new Vector2(Random.Range(-8f, 8f), Random.Range(4.5f, 3.5f)), Quaternion.identity);
    }

    IEnumerator takeDamage()
    {
        canTakeDamage = false;
        /*for (int i = 0; i<3; i++)
        {
            colorAlpha.a = 0.2f;
            yield return new WaitForSeconds(0.2f);
            colorAlpha.a = 0.5f;
            yield return new WaitForSeconds(0.5f);
        }*/
        colorAlpha.a = 0.5f;
        yield return new WaitForSeconds(1f);
        colorAlpha.a = 1f;
        canTakeDamage = true;
    }

}
