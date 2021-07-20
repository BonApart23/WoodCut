using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodRotation : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        RotateWood();
    }

    private void RotateWood()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
