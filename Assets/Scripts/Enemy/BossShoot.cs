using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public float changeAtackTime;
    public float timeBetweenAtacks;
    public float changeTime;

    private void Start()
    {
        Invoke("FirstAtack", 5f);
        changeTime = -5f;
    }

    private void Update()
    {
        changeTime += Time.deltaTime;
        if(changeTime >= changeAtackTime + timeBetweenAtacks)
        {
            ChangeAtack();
            changeTime = 0;
        }
    }

    public void FirstAtack()
    {
        gameObject.GetComponent<BossAtack0>().enabled = true;
        StartCoroutine(TimeBetweenAtacks());
    }

    public void ChangeAtack()
    {
        int a = Random.Range(0, 3);

        switch (a)
        {
            case 0:
                gameObject.GetComponent<BossAtack0>().enabled = true;
                gameObject.GetComponent<BossAtack1>().enabled = false;
                gameObject.GetComponent<BossAtack2>().enabled = false;
                StartCoroutine(TimeBetweenAtacks());
                break;
            case 1:
                gameObject.GetComponent<BossAtack0>().enabled = false;
                gameObject.GetComponent<BossAtack1>().enabled = true;
                gameObject.GetComponent<BossAtack2>().enabled = false;
                StartCoroutine(TimeBetweenAtacks());
                break;
            case 2:
                gameObject.GetComponent<BossAtack0>().enabled = false;
                gameObject.GetComponent<BossAtack1>().enabled = false;
                gameObject.GetComponent<BossAtack2>().enabled = true;
                StartCoroutine(TimeBetweenAtacks());
                break;
        }
    }

    IEnumerator TimeBetweenAtacks()
    {
        yield return new WaitForSeconds(changeAtackTime - timeBetweenAtacks);
        gameObject.GetComponent<BossAtack0>().enabled = false;
        gameObject.GetComponent<BossAtack1>().enabled = false;
        gameObject.GetComponent<BossAtack2>().enabled = false;
    } 
}
