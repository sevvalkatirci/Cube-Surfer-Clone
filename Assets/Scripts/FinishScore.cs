using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishScore : MonoBehaviour
{
    CollectableCubes collectableCubes;
    CollectCubes collectCubes;
    MoveForward moveForward;
    SwerveMovement swerveMovement;
    [SerializeField]
    Canvas endGame;
    [SerializeField]
    Text scoreText;
    private bool isTrigger = true;
    private static int x;

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
                x++;
                collectCubes.cubes.Remove(other.gameObject);
                if (collectCubes.cubes.Count <= 1)
                {
                    moveForward.speed = 0;
                    swerveMovement.enabled = false;
                    int score = Coin.score * x;
                    scoreText.text = score.ToString();
                    endGame.gameObject.SetActive(true);
                    return;
                }
                Destroy(other.gameObject);
                isTrigger = false;
            }
        }
    }
}
