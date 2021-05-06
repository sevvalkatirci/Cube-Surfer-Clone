using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICount : MonoBehaviour
{
    [SerializeField]
    Text text;


    void Update()
    {
        Vector3 countPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        text.transform.position = countPosition;
    }
}
