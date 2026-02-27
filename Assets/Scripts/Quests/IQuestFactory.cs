using System;

/// <summary>
/// Defines a class with a static creation method for an <see cref="IQuest"/> instance
/// </summary>
public interface IQuestFactory
{
    /// <summary>
    /// An <see cref="Action"/> invoked when the quest is completed. Contains a reference to the <see cref="IQuest"/> thats starting for cleanup and the <see cref="IQuestFactory"/> that created it
    /// </summary>
    Action<QuestEventArgs<IQuest>> OnQuestStarted { get; set; }
    /// <summary>
    /// An <see cref="Action"/> invoked when the quest is completed. Contains a reference to the <see cref="IQuest"/> thats ending for cleanup and the next <see cref="IQuestFactory"/> for the quest that comes after this quest's completion
    /// </summary>
    Action<QuestEventArgs<IQuest>> OnQuestEnded { get; set; }

    /// <summary>
    /// Creates and initializes the factory's <see cref="IQuest"/> implementation
    /// </summary>
    /// <returns>The newly initialize <see cref="IQuest"/></returns>
    IQuest CreateInstanceAndInitialize();
}
