using System;
using UnityEngine;
[Serializable]
public class GiveFindItemQuestCommand : INPCCommand
{
    [SerializeField] FindItemQuestDefinitionSO m_questDefinition;


    public void Execute(GameObject interacted, GameObject executionRequester)
    {
        if (executionRequester.TryGetComponent(out QuestManager questManager))
        {
            questManager.StartQuest(m_questDefinition);
        }
    }
}
