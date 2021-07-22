using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSet : MonoBehaviour
{
    [SerializeField] private GameObject[] _woodParts;
    void Start()
    {
        InitializeWoodArray();
        float offset = 0;
        Debug.Log(_woodParts.Length);
        for (int i = 0; i < _woodParts.Length; i++)
        {
            _woodParts[i].GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 0.00588f);
            _woodParts[i].GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(1, 0 + offset);
            offset += 0.00588f;
        }
    }
    private void InitializeWoodArray()
    {
        _woodParts = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _woodParts[i] = transform.GetChild(i).gameObject;
        }
    }
}
