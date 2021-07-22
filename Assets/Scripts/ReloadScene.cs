using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadScene : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(reload);
    }

    private void reload()
    {
        SceneManager.LoadScene(0);
    }
}
