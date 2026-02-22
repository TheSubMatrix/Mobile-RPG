using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Defines the fields that any quest instance must contain
/// </summary>
public interface IQuest
{
    /// <summary>
    /// The current percentage progress of the quest completion
    /// </summary>
    float Progress { get; }
}

