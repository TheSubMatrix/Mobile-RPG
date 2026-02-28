using System;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// A base class for quest definitions that can be used to create and initialize quest instances. Automatically links generic <see cref="UnityEvent"/> from <see cref="IQuestDefinition{TQuest}"/> to the non-generic <see cref="UnityEvent"/> from <see cref="IQuestFactory"/>.
/// </summary>
/// <typeparam name="TQuest">The type of <see cref="IQuest"/> that this factory should create</typeparam>
public abstract class QuestDefinitionSO<TQuest> : ScriptableObject, IQuestDefinition<TQuest> where TQuest : IQuest
{
    /// <summary>
    /// A reference to the <see cref="IQuestFactory"/> that this should be chained after the <see cref="IQuest"/> that this <see cref="IQuestFactory"/> creates completes
    /// </summary>
    [field: SerializeField]public InterfaceReference<IQuestFactory, ScriptableObject> ChainedQuest { get; set; } = new();
    /// <inheritdoc/>
    [field: SerializeField] public UnityEvent<QuestEventArgs<TQuest>> OnQuestInstanceStarted { get; private set; }
    /// <inheritdoc/>
    [field: SerializeField] public UnityEvent<QuestEventArgs<TQuest>> OnQuestInstanceEnded { get; private set; }
    /// <inheritdoc/>
    public Action<QuestEventArgs<IQuest>> OnQuestStarted { get; set; } = delegate { };
    /// <inheritdoc/>
    public Action<QuestEventArgs<IQuest>> OnQuestEnded { get; set; } = delegate { };
    /// <inheritdoc/>
    public IQuest CreateInstanceAndInitialize()
    {
        OnQuestInstanceStarted.AddListener(HandleQuestStarted);

        UnityAction<QuestEventArgs<TQuest>> endHandler = null;
        endHandler = args =>
        {
            OnQuestEnded?.Invoke(args);
            OnQuestInstanceStarted.RemoveListener(HandleQuestStarted);
            OnQuestInstanceEnded.RemoveListener(endHandler);
        };
        OnQuestInstanceEnded.AddListener(endHandler);

        return CreateAndInitializeQuest();
    }

    void HandleQuestStarted(QuestEventArgs<TQuest> args)
    {
        OnQuestStarted?.Invoke(args);
    }
    /// <summary>
    /// How this factory should create and initialize a new quest instance of type <typeparamref name="TQuest"/>
    /// </summary>
    /// <returns>The created <typeparamref name="TQuest"/> instance</returns>
    protected abstract TQuest CreateAndInitializeQuest();
}