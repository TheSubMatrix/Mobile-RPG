public readonly struct QuestEventArgs<TQuest> where TQuest : IQuest
{
    public QuestEventArgs(TQuest quest, IQuestFactory creator, IQuestFactory next = null)
    {
        Quest = quest;
        Creator = creator;
        Next = next;
    }
    public readonly TQuest Quest;
    public readonly IQuestFactory Creator;
    public readonly IQuestFactory Next;

    public static implicit operator QuestEventArgs<IQuest>(QuestEventArgs<TQuest> args) =>
        new(args.Quest, args.Creator, args.Next);
}
