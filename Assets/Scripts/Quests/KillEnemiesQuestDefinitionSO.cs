using System;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Defines how to build out a <see cref="KillEnemiesQuest"/> and holds <see cref="UnityEvent"/> references for the object to call back to
/// </summary>
[CreateAssetMenu(fileName = "New Kill Enemies Quest Definition", menuName = "Scriptable Objects/Quest Definitions/Kill Enemies Quest Definition")]
public class KillEnemiesQuestDefinitionSO : ScriptableObject, IQuestDefinition<KillEnemiesQuest>
{
    /// <inheritdoc/>
    public Action<IQuest, IQuestFactory> OnQuestEnded { get; } = delegate { };
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
        OnQuestInstanceEnded.AddListener(OnQuestEnded.Invoke);
        return KillEnemiesQuest.CreateAndInitialize(this);
    }
    /// <inheritdoc/>
    [field: SerializeField] public UnityEvent<KillEnemiesQuest> OnQuestInstanceStarted { get; private set; }
    /// <inheritdoc/>

    [field: SerializeField] public UnityEvent<KillEnemiesQuest, IQuestFactory> OnQuestInstanceEnded { get; private set; } = new();
}