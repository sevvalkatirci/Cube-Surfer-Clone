using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCubes : MonoBehaviour
{
    CollectableCubes collectableCubes;
    Coin coin;
    [SerializeField]
    public Transform targetPosition;
    [SerializeField]
    Canvas uiCount;
    [SerializeField]
    Canvas gamePlay;
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    public GameObject firstCube;
    private float heightOffset = 1f;
    private float currentHeight = 0;
    public float cameraHeight = 0;
    private bool isStarted = true;
    private bool isTrigger = true;
    public List<GameObject> cubes = new List<GameObject>();

    private void Awake()
    {
        gamePlay.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTrigger) {

            collectableCubes = other.GetComponent<CollectableCubes>();
            coin = other.GetComponent<Coin>();
            if (collectableCubes)
            {
                Destroy(other.gameObject);
                firstCube.transform.position = firstCube.transform.position + new Vector3(0, 1, 0);
                InstantiateCubes();
                isTrigger = false;
            }
            isTrigger = true;
        }
            
    }

    private void InstantiateCubes()
    {
        if (isStarted)
        {
            cubes.Add(firstCube);
            isStarted = false;
        }
        GameObject newCube = Instantiate(cube, targetPosition.position + new Vector3(0, currentHeight, 0), Quaternion.identity);
        newCube.transform.parent = targetPosition;
        StartCoroutine(UIenable());
        currentHeight += heightOffset;
        cubes.Add(newCube);
        cameraHeight++;
    }

    IEnumerator UIenable()
    {
        uiCount.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        uiCount.gameObject.SetActive(false);
    }
}
