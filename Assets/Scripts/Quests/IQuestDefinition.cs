using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Defines an object in charge of creating and initializing an <see cref="IQuest"/> and handling static references to any <see cref="UnityEvent"/> that it outputs
/// </summary>
/// <typeparam name="TQuest">the type of <see cref="IQuest"/> that this definition creates, initializes, and handles <see cref="UnityEvent"/> for</typeparam>
public interface IQuestDefinition<TQuest> : IQuestFactory where TQuest : IQuest
{
    /// <summary>
    /// A <see cref="UnityEvent"/> invoked when an instance of the <see cref="TQuest"/> created from this object is started
    /// </summary>
    UnityEvent<TQuest, IQuestFactory> OnQuestInstanceStarted { get; }
    /// <summary>
    /// A <see cref="UnityEvent"/> invoked when an instance of the <see cref="TQuest"/> created from this object has completed
    /// </summary>
    UnityEvent<TQuest, IQuestFactory> OnQuestInstanceEnded { get; }
}