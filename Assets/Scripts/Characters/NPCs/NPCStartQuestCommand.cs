using System;
using UnityEngine;
[Serializable]
public class NPCStartQuestCommand : INPCCommand
{
    [SerializeField] InterfaceReference<IQuestFactory, ScriptableObject> m_questFactory; 
    public void Execute(GameObject interacted, GameObject executionRequester)
    {
        if(!executionRequester.TryGetComponent(out QuestManager questManager)){return;}
        questManager.StartQuest(m_questFactory.Value);
    }
}
