using System;
using UnityEngine;
/// <summary>
/// A quest where the user finds a specified item
/// </summary>
public class FindItemQuest : IQuest
{
    Action<IQuest, IQuestFactory> m_onQuestEnded;
    IQuestFactory m_nextQuest;
    ItemSO m_itemToFind;
    FindItemQuest() { }
    /// <summary>
    /// Creates the quest instance and initializes it with the event references and data needed for it to run independently
    /// </summary>
    /// <param name="definition">The quest definition creating the quest</param>
    /// <returns>The new <see cref="FindItemQuest"/> instance</returns>
    public static FindItemQuest CreateAndInitialize(FindItemQuestDefinitionSO definition)
    {
        FindItemQuest quest = new()
        {
            m_itemToFind = definition.ItemToFind
        };
        quest.m_onQuestEnded += definition.OnQuestEnded.Invoke;
        quest.m_nextQuest = definition.NextQuest.Value;
        definition.OnQuestInstanceStarted.Invoke(quest);
        Debug.Log($"Quest {quest.GetType().Name} started");
        return quest;
    }
    void CheckItemFound(ItemSO item)
    {
        if (item != m_itemToFind) return;
        m_onQuestEnded?.Invoke(this, m_nextQuest);
    }
    
    /// <inheritdoc/>
    public float Progress => 0;
}