using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentActivation : MonoBehaviour
{
    [SerializeField] private GameObject instrument;
    [SerializeField] private Button button;
    [SerializeField] private Vector3 instrumentCoordinates;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ActivateInstrument);
    }

    private void ActivateInstrument()
    {
        instrument.transform.position = instrumentCoordinates;
    }
}
