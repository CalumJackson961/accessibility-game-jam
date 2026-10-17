using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Motor { Left, Right, Both }

public class HapticsManager : MonoBehaviour
{
    const string PrefKey = "rumbleIntensity";

    static HapticsManager instance;
    public static HapticsManager Instance
    {
        get
        {
            if (instance == null)
            {
                var go = new GameObject("HapticsManager");
                instance = go.AddComponent<HapticsManager>();
            }
            return instance;
        }
    }

    public float Intensity { get; private set; } = 1f;     // 0 to 1, set by the slider
    public event Action<float> IntensityChanged;

    bool leftOn;     // heavy, low-frequency motor
    bool rightOn;    // light, high-frequency motor
    Coroutine leftRoutine;
    Coroutine rightRoutine;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Bootstrap() { var _ = Instance; }

    void Awake()
    {
        if (instance != null && instance != this) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Intensity = PlayerPrefs.GetFloat(PrefKey, 1f);
    }

    public void SetIntensity(float value)
    {
        value = Mathf.Clamp01(value);
        if (Mathf.Approximately(value, Intensity)) return;

        Intensity = value;
        PlayerPrefs.SetFloat(PrefKey, Intensity);
        IntensityChanged?.Invoke(Intensity);
    }

    // Rumble the left motor, the right motor, or both, for the given seconds
    public void Rumble(Motor motor, float seconds)
    {
        if (motor == Motor.Left || motor == Motor.Both)
        {
            if (leftRoutine != null) StopCoroutine(leftRoutine);
            leftRoutine = StartCoroutine(MotorRoutine(true, seconds));
        }

        if (motor == Motor.Right || motor == Motor.Both)
        {
            if (rightRoutine != null) StopCoroutine(rightRoutine);
            rightRoutine = StartCoroutine(MotorRoutine(false, seconds));
        }
    }

    IEnumerator MotorRoutine(bool left, float seconds)
    {
        if (left) leftOn = true; else rightOn = true;
        Apply();

        yield return new WaitForSecondsRealtime(seconds);

        if (left) leftOn = false; else rightOn = false;
        Apply();
    }

    // Sends the active motors to the controller at the slider's intensity
    void Apply()
    {
        bool silent = Intensity <= 0f || (!leftOn && !rightOn);

        foreach (var pad in Gamepad.all)
        {
            if (silent)
                pad.ResetHaptics();
            else
                pad.SetMotorSpeeds(leftOn ? Intensity : 0f, rightOn ? Intensity : 0f);
        }
    }

    void OnDisable()
    {
        foreach (var pad in Gamepad.all)
            pad.ResetHaptics();
    }
    void OnApplicationPause(bool paused) { if (paused) PlayerPrefs.Save(); }
    void OnApplicationQuit() { PlayerPrefs.Save(); }
}