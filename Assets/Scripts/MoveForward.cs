using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    public float speed = 1f;

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
