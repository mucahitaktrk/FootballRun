using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyManager : MonoBehaviour
{
    private float friendlySpawnTime;
    [SerializeField] private FriendlyPool friendlyPool;
    [SerializeField] private GameObject player = null;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        friendlySpawnTime = Random.Range(0f, 4f);
        StartCoroutine(nameof(EnemySpawnRoutine));
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            var obj = friendlyPool.GetFriendlyObject();
            obj.transform.position = new Vector3(1.3f, 0, player.transform.position.z + 5f);
            yield return new WaitForSeconds(Random.Range(0.5f, 3.5f));
        }
    }
}
