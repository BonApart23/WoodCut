
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoleCut : MonoBehaviour
{
    [SerializeField] private float scaleSpeed;
    [SerializeField] private float instrumentSpeed;
    [SerializeField] private bool canCut;
    [SerializeField] private Texture cuttedWood;
    [SerializeField] private Texture deepCuttedWood;
    [SerializeField] private GameObject wood;
    private GameObject[] _woodParts;
    private float _instrumentSpeed;

    private void Start()
    {
        canCut = true;
        wood = GameObject.Find("Wood");
        InitializeWoodArray();
        _instrumentSpeed = gameObject.GetComponent<Move3D>().dragSpeed;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!CheckScaleOnZero(collision.gameObject))
        {
            DoRecoil();
            collision.transform.localScale = new Vector3(collision.transform.localScale.x - scaleSpeed, collision.transform.localScale.y, collision.transform.localScale.z - scaleSpeed);
            collision.gameObject.GetComponent<MeshRenderer>().material.mainTexture = cuttedWood;
            if (collision.transform.localScale.x <= 0.15)
                collision.gameObject.GetComponent<MeshRenderer>().material.mainTexture = deepCuttedWood;
            else
                PaintCloseParts(collision.gameObject);
            ChangeInstrumentSpeed(0.00f);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        ChangeInstrumentSpeed(_instrumentSpeed);
    }

    private void DoRecoil()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.002f);
    }

    private void ChangeInstrumentSpeed(float speed)
    {
        gameObject.GetComponent<Move3D>().dragSpeed = speed;
    }

    private void PaintCloseParts(GameObject collision)
    {
        InitializeWoodArray();
        for (int i = 0; i < _woodParts.Length; i++)
        {
            if (_woodParts[i].name == collision.transform.name)
            {
                _woodParts[i+1].gameObject.GetComponent<MeshRenderer>().material.mainTexture = cuttedWood;
                _woodParts[i-1].gameObject.GetComponent<MeshRenderer>().material.mainTexture = cuttedWood;
                break;
            }
        }

    }

    private void InitializeWoodArray()
    {
        _woodParts = new GameObject[wood.transform.childCount];
        for (int i = 0; i < wood.transform.childCount; i++)
        {
            _woodParts[i] = wood.transform.GetChild(i).gameObject;
        }
    }

    private bool CheckScaleOnZero(GameObject collision)
    {
        if (collision.transform.localScale.x <= 0f)
        {
            collision.transform.localScale = new Vector3(0, collision.transform.localScale.y, 0);
            if (canCut)
            {
                StartCoroutine(nameof(CanCut));
                CutSmallerPart(collision);
            }
            return true;
        }
        return false;
    }

    private void CutSmallerPart(GameObject collision)
    {
        var Parent = new GameObject();
        Parent.name = "SmallPart";
        int counter;
        InitializeWoodArray();
        for (int i = 0; i < _woodParts.Length; i++)
        {
            Debug.Log("collision.transform.name " + collision.transform.name);
            if (_woodParts[i].name == collision.transform.name)
            {
                    Cut(i);
                    break;
            }
        }

        void Cut(int i)
        {
            if (i < _woodParts.Length / 2)
                counter = -1;
            else
                counter = 1;
            Debug.Log("counter " + counter);
            while (i > 0 || i < _woodParts.Length)
            {
                try
                {
                    Debug.Log("index " + i);
                    _woodParts[i].transform.SetParent(Parent.transform);
                    i += counter;
                }
                catch (Exception)
                {
                    break;
                }
            }
            StartCoroutine(DestroyParent(Parent));
        }
    }

        public IEnumerator CanCut()
        {
            canCut = false;
            yield return new WaitForSecondsRealtime(2);
            canCut = true;
            yield break;
        }

        IEnumerator DestroyParent(GameObject parent)
        {
            parent.AddComponent(typeof(Rigidbody));
            yield return new WaitForSecondsRealtime(3);
            Destroy(parent);
            InitializeWoodArray();
            yield break;
        }
}



