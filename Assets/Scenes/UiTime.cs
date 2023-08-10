using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiTime : MonoBehaviour
{
    [SerializeField] private int time;
    [SerializeField] private TextMeshProUGUI textTime;

    private void Start()
    {
        textTime.text = time.ToString();
    }

    private void Update()
    {
        float timer = Time.timeSinceLevelLoad;
        textTime.text = timer.ToString();
    }
}
