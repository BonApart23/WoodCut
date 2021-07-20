using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Move3D : MonoBehaviour
{
    public Vector2 ZValues;
    public float dragSpeed = 1f; Vector3 lastMousePos;

    void OnMouseDown()
    {
        lastMousePos = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        Vector3 delta = Input.mousePosition - lastMousePos;
        Vector3 pos = transform.position;
        pos.z += delta.y * dragSpeed;
        pos.x += delta.x * dragSpeed;
        transform.position = pos;
        lastMousePos = Input.mousePosition;
    }
    /*void Update()
    {
        if (transform.position.x > ZValues.y)
            transform.position = new Vector3(transform.position.x, transform.position.y, ZValues.y);
        else if (transform.position.x < ZValues.x)
            transform.position = new Vector3(transform.position.x, transform.position.y, ZValues.x);
    }*/

}
