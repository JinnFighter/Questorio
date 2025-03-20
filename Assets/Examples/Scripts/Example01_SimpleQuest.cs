using Logic.Scripts.Questorio;
using Logic.Scripts.Questorio.Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.Scripts
{
    public class Example01_SimpleQuest : MonoBehaviour
    {
        [SerializeField] private QuestDescriptionScriptable _questDescription;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _textHeader;
        [SerializeField] private TextMeshProUGUI _textDescription;
        [SerializeField] private TextMeshProUGUI _textProgress;
        private readonly QuestorioService _questorioService = new();
        private IQuest _quest;

        private void Awake()
        {
            _quest = new QuestBase(0, _questDescription);
            _questorioService.Init();
            _button.onClick.AddListener(HandleButtonClicked);
            _textHeader.text = _quest.Header;
            _textDescription.text = _quest.Description;
            _quest.OnProgressUpdated += HandleQuestProgressUpdated;
            HandleQuestProgressUpdated(_quest.CurrentProgress);
        }

        private void OnDestroy()
        {
            _quest.OnProgressUpdated -= HandleQuestProgressUpdated;
            _button.onClick.RemoveListener(HandleButtonClicked);
            _questorioService.Terminate();
        }

        private void HandleQuestProgressUpdated(int progress)
        {
            _textProgress.text = string.Format(_quest.ProgressText, _quest.CurrentProgress, _quest.MaxProgress);
        }

        private void HandleButtonClicked()
        {
            if (_quest.IsCompleted) return;
            _quest.AddProgress();
        }
    }
}