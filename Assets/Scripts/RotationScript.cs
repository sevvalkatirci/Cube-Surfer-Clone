using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    MoveForward player;
    [SerializeField]
    Camera camera;
    NewCameraFollow newCameraFollow;
    public static bool isRotate = false;

    private void Start()
    {
        newCameraFollow = FindObjectOfType<NewCameraFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<MoveForward>();
        if (player)
        {
            isRotate = true;
            Debug.Log("Hi");
            newCameraFollow.offset = new Vector3(-8, 3, 0);
            other.gameObject.transform.Rotate(0, 90, 0);
           // camera.transform.Rotate(0, 90, 0);

        }   
    }
}
