using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public GameObject[] SpawnPoint;
    public GameObject[] towersSpawn;
    Vector2[] vector2;

    public int waves;
    public float timeToSpawn;
    public float timeCd;
    private bool canSpawn;

    [SerializeField]
    private void Start()
    {
        vector2 = new Vector2[SpawnPoint.Length];
        for(int i = 0; i < SpawnPoint.Length; i++)
        {
            vector2[i] = SpawnPoint[i].transform.position;
        }
        
        canSpawn = false;
        StartCoroutine(SpawnCd());
        StartCoroutine(SpawnTowers());
    }
    void Update()
    {
        if (canSpawn && waves > 0)
        {
            SpawnAenemy(EnemyPrefabs[Random.Range(0,6)]);
            StartCoroutine(SpawnCd());
            waves--;
        }

    }

    private void SpawnAenemy(GameObject enemy)
    {
        Debug.Log("Enemy Has spawned");
        for(int i = 0; i < SpawnPoint.Length; i++)
        {
            Instantiate(EnemyPrefabs[Random.Range(0,5)], vector2[i], Quaternion.identity);
        }
    }

    IEnumerator SpawnCd()
    {
        canSpawn = false;
        yield return new WaitForSeconds(timeToSpawn);
        timeToSpawn = timeCd;
        canSpawn = true;
    }

    IEnumerator SpawnTowers()
    {
        yield return new WaitForSeconds(timeToSpawn - 2);
        for(int i = 0; i < towersSpawn.Length; i++)
        {
            towersSpawn[i].SetActive(true);
        }
    }
}
