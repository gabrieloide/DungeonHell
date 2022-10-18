using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float healtAmount;
    public bool canTakeDamage;
    public Color colorAlpha;
    public GameObject healtBar;
    private Vector2 scaleChange, positionChange;
    public bool color; //true= Red & False= Blue
    public bool kamikaze; //Only kakikaze =true
    public bool tower; //Only tower =true

    private void Start()
    {
        scaleChange.x = 1.5f;
        scaleChange.y = 0.2f;
        positionChange.y = 1f;

        canTakeDamage = true;
        colorAlpha = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorAlpha;

        healtBar.transform.localScale = scaleChange;
        healtBar.transform.localPosition = positionChange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && canTakeDamage)
        {
            //Red enemy
            if(color)
            {
                healtAmount -= 1f;
                if (tower)
                {
                    scaleChange.x -= 0.3f;
                    positionChange.x -= 0.15f;
                }
                else
                {
                    scaleChange.x -= 0.5f;
                    positionChange.x -= 0.25f;
                }
                StartCoroutine(takeDamage());
            }
            //Blue enemy
            if(!color)
            {
                healtAmount -= 1f;
                if (tower)
                {
                    scaleChange.x -= 0.3f;
                    positionChange.x -= 0.15f;
                }
                else
                {
                    scaleChange.x -= 0.5f;
                    positionChange.x -= 0.25f;
                }
                StartCoroutine(takeDamage());
            }
            //Only Kamikaze
            if(kamikaze)
            {
                healtAmount -= 1f;
            }
        }
    }

    IEnumerator takeDamage()
    {
        canTakeDamage = false;
        colorAlpha.a = 0.4f;
        yield return new WaitForSeconds(1f);
        colorAlpha.a = 1f;
        canTakeDamage = true;
    }

}
