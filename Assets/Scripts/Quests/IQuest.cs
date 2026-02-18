using UnityEngine.Events;
public interface IQuest
{
    public UnityEvent OnQuestStarted { get; }
    public UnityEvent<IQuest> OnQuestCompleted { get; }
}
