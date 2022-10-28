using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBuff : MonoBehaviour
{
    public GameObject[] buffs;
    private int probability;

    void Update()
    {
        if (gameObject.GetComponent<EnemyHealth>().healtAmount <= 0)
        {
            enemyDie();
        }
    }

    public void enemyDie()
    {
        probability = Random.Range(0, 100);
        if(probability >= 0 && probability < 10)
        {
            Instantiate(buffs[0], this.transform.position, Quaternion.identity);
        }
        else if(probability >= 10 && probability < 20)
        {
            Instantiate(buffs[1], this.transform.position, Quaternion.identity);

        }
        else if(probability >= 20 && probability < 30)
        {
            Instantiate(buffs[2], this.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
