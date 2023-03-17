using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
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
    public static ClickManager instance;

    //vars
    public Selectable currentSelected;
    public Selectable currentHover;

    public void SetHover(Selectable hovered)
    {
        currentHover = hovered;
    }

    public void SetSelected(Selectable selected)
    {
        if (currentSelected != null) { currentSelected.EndSelect(); }
        currentSelected = selected;
    }

    //============= select object ================
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Selectable selected = currentSelected;
            if (currentSelected != null && !EventSystem.current.IsPointerOverGameObject()) {
                currentSelected.EndSelect();
                currentSelected = null;
            }
            if (currentHover != null && selected != currentHover) {
                currentHover.BeginSelect();
            }
        }
    }
}
