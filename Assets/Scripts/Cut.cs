using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1" + collision.gameObject.name);
    }
}
