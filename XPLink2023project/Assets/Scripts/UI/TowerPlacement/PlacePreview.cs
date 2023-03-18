using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePreview : MonoBehaviour
{
    [SerializeField] private Color validColor = Color.white;
    [SerializeField] private Color invalidColor = Color.red;

    [SerializeField] private SpriteRenderer visuals;
    private List<GameObject> objectsInRange;
    public bool IsValid { get { return objectsInRange.Count == 0; } }

    private void Start()
    {
        objectsInRange = new();
        visuals.color = validColor;
    }

    // ============= position ============
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    //=========== handle collisions =============
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger) {
            objectsInRange.Add(collision.gameObject);
            if (objectsInRange.Count == 1) {
                visuals.color = invalidColor;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        objectsInRange.Remove(collision.gameObject);
        if (objectsInRange.Count == 0) {
            visuals.color = validColor;
        }
    }

    //=========== handle disable ===========
    private void OnDisable()
    {
        objectsInRange.Clear();
    }
}
