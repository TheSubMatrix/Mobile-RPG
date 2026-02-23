using System;
using UnityEngine;
/// <summary>
/// A quest where the user kills a specified number of enemies
/// </summary>
public class FindItemQuest : IQuest
{
    uint m_currentKills;
    uint m_requiredKills;
    Action<IQuest, IQuestFactory> m_onQuestEnded;
    IQuestFactory m_nextQuest;
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
            m_requiredKills = definition.TotalKillCount
        };
        quest.m_onQuestEnded += definition.OnQuestEnded.Invoke;
        quest.m_nextQuest = definition.NextQuest.Value;
        definition.OnQuestInstanceStarted.Invoke(quest);
        Debug.Log($"Quest {quest.GetType().Name} started");
        return quest;
    }

    /// <summary>
    /// Increments the kill count for this quest
    /// </summary>
    /// <param name="count">the amount of kills to increment the quest by</param>
    public void IncrementKillCount(uint count)
    {
        m_currentKills += count;
        if (m_currentKills < m_requiredKills) return;
        m_onQuestEnded.Invoke(this, m_nextQuest);
    }
    /// <inheritdoc/>
    public float Progress => (float)m_currentKills / m_requiredKills;
}