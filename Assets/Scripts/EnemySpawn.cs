using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    [SerializeField]


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnAenemy(EnemyPrefabs[UnityEngine.Random.Range(0,6)]);
        }

    }

    private void SpawnAenemy(GameObject enemy)
    {
        Debug.Log("Enemy Has spawned");
        Instantiate(enemy, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)), Quaternion.identity);
    }

}
