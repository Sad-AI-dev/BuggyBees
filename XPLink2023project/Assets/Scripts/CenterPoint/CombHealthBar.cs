using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class CombHealthBar : HealthBar
{
    [SerializeField] private List<GameObject> emptyVisuals;
    private int hiddenCount;
    private float oldPercent;

    private void Start()
    {
        hiddenCount = 0;
        oldPercent = 1f;
    }

    public override void UpdateHealthBar(float percentage)
    {
        if (percentage < oldPercent) {
            ShowNextEmptyComb();
        }
        oldPercent = percentage;
    }
    private void ShowNextEmptyComb()
    {
        if (hiddenCount < emptyVisuals.Count) {
            emptyVisuals[hiddenCount].SetActive(true);
            hiddenCount++;
        }
    }
}
