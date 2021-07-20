using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoleCut : MonoBehaviour
{
    public float speed;
    [SerializeField] private float scaleSpeed;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1" + collision.gameObject.name);
        collision.transform.localScale = new Vector3(collision.transform.localScale.x - scaleSpeed, collision.transform.localScale.y, collision.transform.localScale.z - scaleSpeed);
    }
}
