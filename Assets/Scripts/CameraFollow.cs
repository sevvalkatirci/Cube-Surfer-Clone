using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 offset;
    CollectCubes collect;

    private void Start()
    {
        collect = FindObjectOfType<CollectCubes>();
        offset = transform.position - target.transform.position;
    }
    private void FixedUpdate()
    {
        transform.position = target.transform.position + offset + new Vector3(0,collect.cameraHeight,0);
        
    }
}
