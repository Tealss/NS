using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spwanTime;
    [SerializeField]
    private Transform[] wayPoints;

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
       while (true)
        { 
            GameObject clone = Instantiate(enemyPrefab);
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.Setup(wayPoints);
            yield return new WaitForSeconds(spwanTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
