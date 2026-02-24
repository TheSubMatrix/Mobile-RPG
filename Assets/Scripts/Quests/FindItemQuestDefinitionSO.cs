using System;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Defines how to build out a <see cref="FindItemQuest"/> and holds <see cref="UnityEvent"/> references for the object to call back to
/// </summary>
[CreateAssetMenu(fileName = "New Find Item Quest Definition", menuName = "Scriptable Objects/Quest Definitions/Find Item Quest Definition")]
public class FindItemQuestDefinitionSO : ScriptableObject, IQuestDefinition<FindItemQuest>
{
    [field: SerializeField] public ItemSO ItemToFind { get; private set; }
    /// <inheritdoc/>
    public Action<IQuest, IQuestFactory> OnQuestEnded { get; set; } = delegate { };
    /// <summary>
    /// A reference to any <see cref="IQuest"/> that will be automatically initiated after this quest completes
    /// </summary>
    [field: SerializeField] public InterfaceReference<IQuestFactory, ScriptableObject> NextQuest { get; private set; }
    [field: SerializeField] public UnityEvent<uint> OnQuestKillCountUpdated { get; private set; }
    /// <summary>
    /// The total number of kills needed to complete this quest
    /// </summary>
    [field: SerializeField] public uint TotalKillCount { get; private set; }
    /// <inheritdoc/>
    public IQuest CreateInstanceAndInitialize()
    {
        UnityAction<FindItemQuest, IQuestFactory> handler = null;
        handler = (quest, next) =>
        {
            OnQuestEnded.Invoke(quest, next);
            OnQuestInstanceEnded.RemoveListener(handler);
        };
        OnQuestInstanceEnded.AddListener(handler);
        return FindItemQuest.CreateAndInitialize(this);
    }
    /// <inheritdoc/>
    [field: SerializeField] public UnityEvent<FindItemQuest> OnQuestInstanceStarted { get; private set; }
    /// <inheritdoc/>
    [field: SerializeField] public UnityEvent<FindItemQuest, IQuestFactory> OnQuestInstanceEnded { get; private set; } = new();
}