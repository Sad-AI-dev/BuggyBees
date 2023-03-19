using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class PlayerVisuals : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        GetComponent<TopDownController>().onChangeMoveDir.AddListener(OnDirChange);
    }

    private void OnDirChange(Vector2 newDir)
    {
        if (newDir.x >= 0f) { sprite.flipX = false; }
        else { sprite.flipX = true; }
    }
}
