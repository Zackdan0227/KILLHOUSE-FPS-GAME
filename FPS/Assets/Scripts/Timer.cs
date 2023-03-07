using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;
    public bool stop;
    // Start is called before the first frame update
    void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }
        timerText.text = currentTime.ToString("0.00");
    }

    public void stopTime()
    {
        stop = true;
    }
}
