using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInput swerveInput;
    [SerializeField]
    private float swerveSpeed = 0.5f;
    [SerializeField]
    private float maxSwerveAmount = 1f;

    private void Awake()
    {
        swerveInput = GetComponent<SwerveInput>();
    }

    private void Update()
    {
        float swerveAmount = swerveInput.MoveFactorX * swerveSpeed * Time.deltaTime;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
        if (RotationScript.isRotate == false)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.3f, 4.3f), 0.5f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 0.5f, Mathf.Clamp(transform.position.z, 195f, 203f));
        }
        
        

    }
}
