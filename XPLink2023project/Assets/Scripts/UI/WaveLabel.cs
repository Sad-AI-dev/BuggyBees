using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveLabel : MonoBehaviour
{
    private TMP_Text label;
    private string baseString;
    private int wave;

    private void Start()
    {
        label = GetComponent<TMP_Text>();
        baseString = label.text;
        wave = 0;
        UpdateLabel();
    }

    public void OnSpawnNextWave()
    {
        wave++;
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        label.text = baseString + wave;
    }
}
