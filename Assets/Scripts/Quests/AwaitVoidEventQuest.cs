public class AwaitVoidEventQuest : IQuest
{
    VoidEventChannel m_eventChannel;
    AwaitVoidEventQuestDefinitionSO m_definition;
    AwaitVoidEventQuest(){}
    public static AwaitVoidEventQuest CreateAndInitialize(AwaitVoidEventQuestDefinitionSO definition)
    {
        AwaitVoidEventQuest quest = new()
        {
            m_eventChannel = definition.m_eventChannel,
            m_definition = definition
        };
        quest.m_eventChannel.OnEventRaised += quest.FinishAndCleanup;
        definition.OnQuestInstanceStarted.Invoke(new(quest, definition));
        return quest;
    }
    void FinishAndCleanup()
    {
        m_eventChannel.OnEventRaised -= FinishAndCleanup;
        m_definition.OnQuestInstanceEnded.Invoke(new(this, m_definition));
    }
    public float Progress => 0;
}
