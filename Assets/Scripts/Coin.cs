using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    MoveForward player;
    public static int score;
    public Text text;
    
    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<MoveForward>();
        if (player)
        {
            Destroy(gameObject);
            score++;
            text.text = score.ToString();
        }
    }
}
