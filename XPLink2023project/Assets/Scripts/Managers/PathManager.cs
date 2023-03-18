using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
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

    public static PathManager instance;

    [SerializeField] private Transform pathHolder;
    public List<Transform> path;

    private void Start()
    {
        foreach (Transform child in pathHolder)
        {
            path.Add(child);
        }
    }
}
