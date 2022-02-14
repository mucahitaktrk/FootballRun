using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyCharacterScript : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Material[] friendlyMateral;
    private Rigidbody rb;

    private void Awake()
    {

        skinnedMeshRenderer = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        int x = Random.Range(0, 2);
        skinnedMeshRenderer.material = friendlyMateral[x];
        int selectNo = Random.Range(2, 22);
        transform.GetChild(selectNo).gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * 5f;
    }

}
