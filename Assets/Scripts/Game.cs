using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    void Start()
    {
    }
    // Update is called once per frame
    //void Update()
    //{    
    //}

    public void Enqueue(int tone)
    {
        Debug.Log(tone.ToString());
    }
}
