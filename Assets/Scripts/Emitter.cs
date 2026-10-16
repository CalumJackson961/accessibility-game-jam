using UnityEngine;
using UnityEngine.Events;

public class Emitter : MonoBehaviour
{
    [SerializeField] UnityEvent<int> m_Enqueue;

    void Start()
    {
        //gameObject.SendMessage("Enqueue", 5.0);
        m_Enqueue.Invoke(123123);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
