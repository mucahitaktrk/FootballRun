using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    private float enemySpawnTime;
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private GameObject player = null;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        enemySpawnTime = Random.Range(0f, 4f);
        StartCoroutine(nameof(EnemySpawnRoutine));
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            var obj = enemyPool.GetEnemyObject();
            obj.transform.position = new Vector3(-1.3f, 0, player.transform.position.z + 30f);
            yield return new WaitForSeconds(Random.Range(0.0f, 1.5f));
        }
    }

}
