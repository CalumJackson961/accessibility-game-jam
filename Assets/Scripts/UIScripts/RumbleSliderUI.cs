using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class RumbleSliderUI : MonoBehaviour
{
    Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = 1f;
        slider.onValueChanged.AddListener(OnSliderMoved);
    }

    void OnEnable()
    {
        slider.SetValueWithoutNotify(HapticsManager.Instance.Intensity);   // show the saved value
        HapticsManager.Instance.IntensityChanged += OnIntensityChanged;
    }

    void OnDisable()
    {
        if (HapticsManager.Instance != null)
            HapticsManager.Instance.IntensityChanged -= OnIntensityChanged;
    }

    void OnSliderMoved(float value)
    {
        HapticsManager.Instance.SetIntensity(value);
        HapticsManager.Instance.Pulse(0.5f, 0.5f, 0.15f);                  // preview buzz
    }

    void OnIntensityChanged(float value)
    {
        slider.SetValueWithoutNotify(value);                               // stay in sync, no extra buzz
    }
}