using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private Queue<GameObject> enemy;
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private int enemySize;

    private void Awake()
    {
        enemy = new Queue<GameObject>();
        for (int i = 0; i < enemySize; i++)
        {
            GameObject go = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(new Vector3(0,180,0)));

            go.SetActive(false);
            enemy.Enqueue(go);
        }
    }

    public GameObject GetEnemyObject()
    {
        GameObject obj = enemy.Dequeue();

        enemy.Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}
