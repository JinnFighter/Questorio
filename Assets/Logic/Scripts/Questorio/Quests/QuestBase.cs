using System;
using UnityEngine;

namespace Logic.Scripts.Questorio.Quests
{
    public class QuestBase : IQuest
    {
        public QuestBase(int currentProgress, IQuestDescription description)
        {
            CurrentProgress = currentProgress;
            Id = description.Id;
            Header = description.Header;
            Description = description.Description;
            MaxProgress = description.MaxProgress;
        }

        public string Id { get; }
        public string Header { get; }
        public string Description { get; }
        public int CurrentProgress { get; private set; }
        public int MaxProgress { get; }
        public bool IsCompleted { get; private set; }
        public bool IsFailed { get; private set; }
        public event Action OnComplete;
        public event Action OnFail;
        public event Action<int> OnProgressUpdated;

        public void CompleteQuest()
        {
            CompleteQuestInner();
        }

        public void FailQuest()
        {
            FailQuestInner();
        }

        public void SetProgress(int progress)
        {
            UpdateProgressInner(progress);
        }

        public void AddProgress(int progress = 1)
        {
            UpdateProgressInner(CurrentProgress + progress);
        }

        private void UpdateProgressInner(int progress)
        {
            var newProgress = Mathf.Clamp(progress, 0, MaxProgress);
            if (CurrentProgress == newProgress) return;

            CurrentProgress = newProgress;
            OnProgressUpdated?.Invoke(CurrentProgress);

            if (CurrentProgress >= MaxProgress) CompleteQuestInner();
        }

        private void CompleteQuestInner()
        {
            if (IsCompleted) return;

            IsCompleted = true;
            OnComplete?.Invoke();
        }

        private void FailQuestInner()
        {
            if (IsFailed) return;
            IsFailed = true;
            OnFail?.Invoke();
        }
    }
}