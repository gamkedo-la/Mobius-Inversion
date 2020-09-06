using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsSlider : MonoBehaviour
{
    public float targetValue = 0.75f;
    private float sliderStopSpeed = 0.0025f;
    private bool sliderActive = false;
    private Slider elimSlider;
    private TMP_Text sliderText;
    private float fillSpeed = 0.0f;

    private void Awake()
    {
        elimSlider = GetComponent<Slider>();
        sliderText = GetComponentInChildren<TMP_Text>();
        sliderActive = false;
    }

    private void FixedUpdate()
    {
        if (sliderActive)
        {
            UpdateSlider();
        }
    }

    public void StartSlider()
    {
        sliderActive = true;
    }

    private void UpdateSlider()
    {
        if (elimSlider.value < targetValue)
        {
            fillSpeed = targetValue - elimSlider.value; // Decelerate slider
            elimSlider.value += fillSpeed * Time.deltaTime;
            sliderText.text = (Mathf.Round(elimSlider.value * 100).ToString() + "%");

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
