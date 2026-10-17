using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Level pattern to repeat
    Queue<int> answer;

    // fill queues per player, combine in Test() function
    Queue<int> player1;
    Queue<int> player2;


    [System.Serializable]
    public class ToneMapping
    {
        public int toneId;
        public AudioSource audioSource;
    }

    [SerializeField] private ToneMapping[] toneMappings;

    private Dictionary<int, AudioSource> toneAudioMap;


    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        player1 = new Queue<int>();
        player2 = new Queue<int>();
        answer = new Queue<int>();
        toneAudioMap = new Dictionary<int, AudioSource>();

        foreach (ToneMapping mapping in toneMappings)
        {
            if (mapping.audioSource != null)
                toneAudioMap[mapping.toneId] = mapping.audioSource;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void PlayTone(int toneId)
    {
        if (toneAudioMap.TryGetValue(toneId, out AudioSource source))
        {
            source.Play();
        }
        else
        {
            Debug.LogWarning($"No AudioSource mapped for tone ID {toneId}");
        }
    }


    public void Enqueue(int toneid, int userid)
    {
        if (userid == 1)
        {
            player1.Enqueue(toneid);
        } else {
            player2.Enqueue(toneid);
        }
    }

    public void InitPattern(Queue<int> answer)
    {
        this.answer = answer;
    }

    public void Test()
    {
        int[] p1 = player1.ToArray();
        int[] p2 = player2.ToArray();

        if (p1.Length < 2 || p2.Length < 3)
        {
            Debug.LogWarning("Not enough tones queued to run Test().");
            return;
        }

        PlayTone(p1[0]);
        PlayTone(p2[0]);
        PlayTone(p1[1]);
        PlayTone(p2[2]);
    }

    public void Reset()
    {
        player1.Clear();
        player2.Clear();
    }
}
