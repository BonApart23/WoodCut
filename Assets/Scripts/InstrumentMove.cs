using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentMove : MonoBehaviour
{
    [SerializeField] private float speedModifier;
    private Touch _touch;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + _touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z + _touch.deltaPosition.y * speedModifier);
            }
        }
    }
}
