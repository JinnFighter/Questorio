using System;

namespace Logic.Scripts.Questorio.Quests
{
    public interface IQuest
    {
        int CurrentProgress { get; }
        int MaxProgress { get; }
        bool IsCompleted { get; }
        bool IsFailed { get; }
        public event Action OnComplete;
        public event Action OnFail;
        public event Action<int> OnProgressUpdated;
        void CompleteQuest();
        void FailQuest();
        void SetProgress(int progress);
        void AddProgress(int progress = 1);
    }
}