using UnityEngine;
using UnityEngine.Events;

public class VoidEventChannelListener : MonoBehaviour
{
    [SerializeField] VoidEventChannel m_eventChannel;
    [SerializeField] UnityEvent m_event;
    void Awake()
    {
        m_eventChannel.OnEventRaised += m_event.Invoke;
    }
}
