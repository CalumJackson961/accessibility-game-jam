using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Level pattern to repeat
    List<int> answer;

    Game game;

    //[System.Serializable]
    //public class ToneMapping
    //{
    //    public int toneId;
    //    public AudioSource audioSource;
    //}

    //[SerializeField] private ToneMapping[] toneMappings;

    //private Dictionary<int, AudioSource> toneAudioMap;


    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        game = new Game();
        //toneAudioMap = new Dictionary<int, AudioSource>();

        //foreach (ToneMapping mapping in toneMappings)
        //{
        //    if (mapping.audioSource != null)
        //        toneAudioMap[mapping.toneId] = mapping.audioSource;
        //}
        DontDestroyOnLoad(gameObject);
    }


    public void Enqueue(TONE tone)
    {
        game.Enqueue(tone);
    }

    public void InitPattern(List<int> answer)
    {
        this.answer = answer;
    }

    public void Test()
    {
        game.CheckAnswer();
    }

    public void Reset()
    {
        game.ResetAnswer();
    }
}
