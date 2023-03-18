using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector2 offsetRange;

    public void SpawnObject(GameObject prefab)
    {
        GameObject gO = Instantiate(prefab);
        gO.transform.position = spawnPoint.transform.position + GetRandomOffset();
    }

    private Vector3 GetRandomOffset()
    {
        return new Vector3(
            Random.Range(-offsetRange.x, offsetRange.x),
            Random.Range(-offsetRange.y, offsetRange.y),
            0f
            );
    }
}
