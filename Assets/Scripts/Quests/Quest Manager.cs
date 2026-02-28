using UnityEngine;

public class QuestManager : MonoBehaviour
{
    IQuest m_currentQuest;
    public void StartQuest(IQuestFactory questFactory)
    {
        m_currentQuest = questFactory.CreateInstanceAndInitialize();
        questFactory.OnQuestEnded += OnQuestEnded;
    }
    void OnQuestEnded(QuestEventArgs<IQuest> args)
    {
        args.Creator.OnQuestEnded -= OnQuestEnded;
        m_currentQuest = null;
        if(args.Next == null){ return;}
        StartQuest(args.Next);
    }
}
