using System;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Defines a class with a static creation method for an <see cref="IQuest"/> instance
/// </summary>
public interface IQuestFactory
{
    /// <summary>
    /// An <see cref="Action"/> invoked when the quest is completed. Contains a reference to the <see cref="IQuest"/> thats ending for cleanup and the next <see cref="IQuestFactory"/> for the quest that comes after this quest's completion
    /// </summary>
    Action<IQuest, IQuestFactory> OnQuestEnded { get; }
    /// <summary>
    /// Creates and initializes the factory's <see cref="IQuest"/> implementation
    /// </summary>
    /// <returns>The newly initialize <see cref="IQuest"/></returns>
    IQuest CreateInstanceAndInitialize();
}
