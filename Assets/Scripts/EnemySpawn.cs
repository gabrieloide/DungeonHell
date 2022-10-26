using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public GameObject[] SpawnPoint;
    Vector2[] vector2;

    public int waves;
    private int wavesCount;
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
    }
    void Update()
    {
        if (canSpawn && wavesCount < waves)
        {
            SpawnAenemy(EnemyPrefabs[Random.Range(0,6)]);
            StartCoroutine(SpawnCd());
            wavesCount++;
        }

    }

    private void SpawnAenemy(GameObject enemy)
    {
        Debug.Log("Enemy Has spawned");
        for(int i = 0; i < SpawnPoint.Length; i++)
        {
            Instantiate(enemy, vector2[i], Quaternion.identity);
        }
    }

    IEnumerator SpawnCd()
    {
        canSpawn = false;
        yield return new WaitForSeconds(timeToSpawn);
        timeToSpawn = timeCd;
        canSpawn = true;
    }
}
