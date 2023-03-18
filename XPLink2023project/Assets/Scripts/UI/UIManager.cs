using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public static UIManager instance;

    [Header("Refs")]
    public GameObject contextPanel;
    public GameObject buildPanel;
    
    //============= build panel =================
    public void ShowBuildPanel()
    {
        if (!contextPanel.activeSelf) {
            ShowContextPanel();
        }
        buildPanel.SetActive(true);
    }

    public void HideBuildPanel()
    {
        buildPanel.SetActive(false);
        contextPanel.SetActive(false);
    }

    //============ context panel ================
    private void ShowContextPanel()
    {
        contextPanel.SetActive(true);
    }

    private void HideContextPanel()
    {
        contextPanel.SetActive(false);
    }
}
