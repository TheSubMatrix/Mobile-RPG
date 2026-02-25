using System;
using UnityEngine;
[Serializable]
public class NPCDialogueCommand : INPCCommand
{
    [SerializeField] string m_dialogue;
    public void Execute(GameObject interacted, GameObject executionRequester)
    {
        interacted.GetComponent<DialogueDisplayRequester>()?.MakeDialogueRequest(m_dialogue);
    }
}
