using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Void Event Channel", menuName = "Event Channels/Void Event Channel" )]
public class VoidEventChannel : ScriptableObject
{
    public UnityAction OnEventRaised;
    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}
