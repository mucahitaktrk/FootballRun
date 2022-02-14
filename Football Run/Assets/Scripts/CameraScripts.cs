using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void Update()
    {
        transform.position = player.transform.position + offset;

    }
}
