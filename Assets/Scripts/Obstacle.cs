using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    CollectableCubes collectableCubes;
    CollectCubes collectCubes;
    MoveForward moveForward;
    SwerveMovement swerveMovement;
    public GameObject firstCube;
    private bool isTrigger = true;
    public GameObject targetPosition;

    private void Start()
    {
        collectCubes = FindObjectOfType<CollectCubes>();
        moveForward = FindObjectOfType<MoveForward>();
        swerveMovement = FindObjectOfType<SwerveMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isTrigger)
        {
            collectableCubes = other.GetComponent<CollectableCubes>();

            if (collectableCubes)
            {
                collectCubes.cubes.Remove(other.gameObject);
                
                if (collectCubes.cubes.Count <= 1)
                {
                    moveForward.speed = 0;
                    swerveMovement.enabled = false;
                    return;
                }
                Destroy(other.gameObject);
                StartCoroutine(wait());
                isTrigger = false;
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        targetPosition.transform.position += new Vector3(0, -1, 0);
        firstCube.transform.position += new Vector3(0, -1, 0);
        collectCubes.cameraHeight--;
    }
}
