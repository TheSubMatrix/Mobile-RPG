using System;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class NPCVoidEventCommand : INPCCommand
{
    [SerializeField] UnityEvent m_onCommandExecuted;
    public void Execute(GameObject interacted, GameObject executionRequester)
    {
        m_onCommandExecuted.Invoke();
    }
}
