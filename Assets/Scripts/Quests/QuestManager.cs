using UnityEngine;

public class QuestManager : MonoBehaviour
{
    IQuestFactory m_questFactory;
    public void StartQuest(IQuestFactory quest)
    {
        m_questFactory = quest;
        quest.CreateInstanceAndInitialize();
        quest.OnQuestEnded += OnQuestEnded;
    }
    void OnQuestEnded(IQuest quest, IQuestFactory nextQuest)
    {
        m_questFactory.OnQuestEnded -= OnQuestEnded;
        if (nextQuest != null) StartQuest(nextQuest);
    }
}
