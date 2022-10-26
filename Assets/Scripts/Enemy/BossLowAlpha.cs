using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLowAlpha : MonoBehaviour
{
    private Color colorAlpha;
    private IEnumerator coroutineLow; 
    private IEnumerator coroutineUp; 
    void Start()
    {
        coroutineLow = lowAlpha();
        coroutineUp = upAlpha();
        colorAlpha = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorAlpha;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coroutineLow = lowAlpha();
            StopCoroutine(coroutineUp);
            StartCoroutine(coroutineLow);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coroutineUp = upAlpha();
            StopCoroutine(coroutineLow);
            StartCoroutine(coroutineUp);
        }
    }
    IEnumerator lowAlpha()
    {
        Debug.Log("startlow");
        while (colorAlpha.a > 0.5f)
        {
            colorAlpha.a -= 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator upAlpha()
    {
        Debug.Log("startup");
        while (colorAlpha.a < 1f)
        {
            colorAlpha.a += 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
