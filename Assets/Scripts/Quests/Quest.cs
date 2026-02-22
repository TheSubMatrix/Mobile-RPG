using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public abstract class Quest<TQuestData> : ScriptableObject, IQuest where TQuestData : IEquatable<TQuestData>
{
    [field:SerializeField] public UnityEvent OnQuestStarted { get; private set; } = new();
    [field:SerializeField] public UnityEvent<IQuest> OnQuestCompleted { get; private set; } = new();
    [SerializeField] SerializableDictionary<TQuestData, InterfaceReference<IQuest, ScriptableObject>> m_checkNextQuests = new();
    public Dictionary<TQuestData, InterfaceReference<IQuest, ScriptableObject>> CheckNextQuests => m_checkNextQuests;
    IQuest CheckQuestCompletion(TQuestData data)
    {
        return m_checkNextQuests.TryGetValue(data, out InterfaceReference<IQuest, ScriptableObject> nextQuest) ? nextQuest.Value : null;
    }
    [field:SerializeField] public UnityEvent<TQuestData> OnQuestDataUpdated { get; protected set; }
}
