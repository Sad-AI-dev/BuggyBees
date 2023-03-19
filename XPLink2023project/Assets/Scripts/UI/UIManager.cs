using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

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
    public UIToggleMover toggleMover;
    
    public void ToggleVisibility()
    {
        toggleMover.StartMove();
    }
}
