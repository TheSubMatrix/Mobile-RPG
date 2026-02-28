using UnityEngine;
[CreateAssetMenu( fileName = "New Await Void Event Quest Definition", menuName = "Quests/Await Void Event Quest Definition")]
public class AwaitVoidEventQuestDefinitionSO : QuestDefinitionSO<AwaitVoidEventQuest>
{
    public VoidEventChannel m_eventChannel;
    protected override AwaitVoidEventQuest CreateAndInitializeQuest()
    {
        return AwaitVoidEventQuest.CreateAndInitialize(this);
    }
}