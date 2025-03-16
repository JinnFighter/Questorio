using Logic.Scripts.Questorio;
using UnityEngine;

namespace Examples.Scripts
{
    public class Example01_SimpleQuest : MonoBehaviour
    {
        private readonly QuestorioService _questorioService = new QuestorioService();

        private void Awake()
        {
            _questorioService.Init();
        }

        private void OnDestroy()
        {
            _questorioService.Terminate();
        }
    }
}