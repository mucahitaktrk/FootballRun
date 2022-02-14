using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyPool : MonoBehaviour
{
    private Queue<GameObject> friendly;
    [SerializeField] private GameObject friendlyPrefab = null;
    [SerializeField] private int friendlySize;

    private void Awake()
    {
        friendly = new Queue<GameObject>();
        for (int i = 0; i < friendlySize; i++)
        {
            GameObject go = Instantiate(friendlyPrefab);

            go.SetActive(false);
            friendly.Enqueue(go);
        }
    }

    public GameObject GetFriendlyObject()
    {
        GameObject obj = friendly.Dequeue();

        friendly.Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}
