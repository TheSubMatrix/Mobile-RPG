using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] InterfaceReference<IQuest, ScriptableObject> m_initialQuest;
    public IQuest CurrentQuest { get; private set; }
    void Awake()
    {
        StartQuest(m_initialQuest.Value);
    }
    void StartQuest(IQuest quest)
    {
        if (quest == null) return;
        CurrentQuest = quest;
        CurrentQuest.OnQuestStarted.Invoke();
        CurrentQuest.OnQuestCompleted.AddListener(OnQuestCompleted);
    }
    void OnQuestCompleted(IQuest nextQuest)
    {
        StartQuest(nextQuest);
    }
}
