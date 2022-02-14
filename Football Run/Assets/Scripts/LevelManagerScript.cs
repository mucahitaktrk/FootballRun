using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    private Queue<GameObject> chunk;

    [SerializeField] private GameObject chunkPrefab = null;
    [SerializeField] private GameObject chunkEndPrefab = null;
    [SerializeField] private int chunkSize;

    private Vector3 vec;
    private void Awake()
    {
        chunk = new Queue<GameObject>();
        vec = Vector3.zero;
        for (int i = 0; i < chunkSize; i++)
        {
            GameObject go = Instantiate(chunkPrefab ,vec,Quaternion.identity);
            vec.z += 10.10f;
            chunk.Enqueue(go);
        }
        Vector3 chunkEndVector = new Vector3();
        chunkEndVector.z += 10.10f * chunkSize;
        Instantiate(chunkEndPrefab, chunkEndVector, Quaternion.identity);

    }
}
