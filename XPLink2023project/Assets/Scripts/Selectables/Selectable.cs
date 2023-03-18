using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer highlighter;
    [Header("State Sprites")]
    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private Sprite selectedSprite;

    private Sprite baseSprite;
    protected bool selected = false;

    public void Start()
    {
        baseSprite = highlighter.sprite;
    }

    public virtual void BeginHover()
    {
        if (!selected) {
            highlighter.sprite = highlightSprite;
        }
        ClickManager.instance.SetHover(this);
    }
    public virtual void EndHover()
    {
        if (!selected) {
            highlighter.sprite = baseSprite;
        }
        ClickManager.instance.SetHover(null);
    }

    public virtual void BeginSelect()
    {
        selected = true;
        highlighter.sprite = selectedSprite;
        ClickManager.instance.SetSelected(this);
    }
    public virtual void EndSelect()
    {
        selected = false;
        highlighter.sprite = baseSprite;
    }

    //============= Detect Mouse =============
    private void OnMouseEnter()
    {
        BeginHover();
    }

    private void OnMouseExit()
    {
        EndHover();
    }
}
