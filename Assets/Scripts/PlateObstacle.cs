using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObstacle : MonoBehaviour
{
    CollectableCubes collectableCubes;
    CollectCubes collectCubes;
    MoveForward moveForward;
    SwerveMovement swerveMovement;
    public GameObject firstCube;
    public GameObject targetPosition;

    private void Start()
    {
        collectCubes = FindObjectOfType<CollectCubes>();
        moveForward = FindObjectOfType<MoveForward>();
        swerveMovement = FindObjectOfType<SwerveMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
            collectableCubes = other.GetComponent<CollectableCubes>();
            if (collectableCubes)
            {
                collectCubes.cubes.Remove(other.gameObject);
                if (collectCubes.cubes.Count <= 0)
                {
                    moveForward.speed = 0;
                    swerveMovement.enabled = false;
                    return;
                }
                Destroy(other.gameObject);
                StartCoroutine(wait());
            }
        

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        targetPosition.transform.position += new Vector3(0, -1, 0);
        firstCube.transform.position += new Vector3(0, -1, 0);
        collectCubes.cameraHeight--;
    }
}
