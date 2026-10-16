using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public float Intensity { get; private set; } = 1f;     // 0 to 1
    public event Action<float> IntensityChanged;           // fires when any slider changes it

    Coroutine current;

    // Creates the manager before the first scene loads, so it never depends on scene setup
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

    // Call this from your game whenever something should rumble
    public void Pulse(float low, float high, float seconds)
    {
        var pad = Gamepad.current;
        if (pad == null || Intensity <= 0f) return;

        if (current != null) StopCoroutine(current);
        current = StartCoroutine(PulseRoutine(pad, low, high, seconds));
    }

    IEnumerator PulseRoutine(Gamepad pad, float low, float high, float seconds)
    {
        pad.SetMotorSpeeds(Mathf.Clamp01(low * Intensity), Mathf.Clamp01(high * Intensity));
        yield return new WaitForSecondsRealtime(seconds);
        pad.ResetHaptics();
    }

    void OnDisable() { Gamepad.current?.ResetHaptics(); }
    void OnApplicationPause(bool paused) { if (paused) PlayerPrefs.Save(); }
    void OnApplicationQuit() { PlayerPrefs.Save(); }
}