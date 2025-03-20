using UnityEngine;

namespace Logic.Scripts.Questorio.Quests
{
    [CreateAssetMenu(fileName = "QuestDescriptionScriptable",
        menuName = "Scriptable Objects/QuestDescriptionScriptable")]
    public class QuestDescriptionScriptable : ScriptableObject, IQuestDescription
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Header { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public string ProgressText { get; private set; }
        [field: SerializeField] public int MaxProgress { get; private set; }
    }
}