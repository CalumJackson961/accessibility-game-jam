using UnityEngine;
using UnityEngine.Events;

public class Emitter : MonoBehaviour
{
    [SerializeField] UnityEvent<int> m_MyEvent;

    void Start()
    {
        //gameObject.SendMessage("Enqueue", 5.0);
        m_MyEvent.Invoke(123123);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
