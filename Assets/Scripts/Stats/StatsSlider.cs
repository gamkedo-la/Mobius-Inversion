using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsSlider : MonoBehaviour
{
    private float targetValue = 0.75f;
    private float sliderStopSpeed = 0.0025f;
    private bool sliderActive = true;
    private Slider elimSlider;
    private float fillSpeed = 0.0f;

    private void Start()
    {
        elimSlider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        if (sliderActive)
        {
            UpdateSlider();
        }
    }

    private void StartSlider()
    {
        sliderActive = true;
    }

    private void UpdateSlider()
    {
        if (elimSlider.value < targetValue)
        {
            fillSpeed = targetValue - elimSlider.value; // Decelerate slider
            elimSlider.value += fillSpeed * Time.deltaTime;

            // Stop slider once it has decelerated to stopping speed
            if (fillSpeed <= sliderStopSpeed)
            {
                StopSlider();
            }
        }
    }
    private void StopSlider()
    {
        fillSpeed = 0.0f;
        elimSlider.value = targetValue;
        sliderActive = false;
    }
}
