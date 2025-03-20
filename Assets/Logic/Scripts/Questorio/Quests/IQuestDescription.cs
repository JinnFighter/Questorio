namespace Logic.Scripts.Questorio.Quests
{
    public interface IQuestDescription
    {
        string Id { get; }
        string Header { get; }
        string Description { get; }
        string ProgressText { get; }
        int MaxProgress { get; }
    }
}
