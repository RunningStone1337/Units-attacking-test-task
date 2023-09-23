using Units;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public enum LoopActionType
    {
        Attack,
        ApplyEffect
    }

    /// <summary>
    /// ��������� ������� ������, �������� �� ���������� �������� ��������.
    /// </summary>
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private GameRound current;
        [SerializeField] private UnitModel currentTurnPlayer;
        [SerializeField] private RoundsHistory history = new();
        [SerializeField] private UnityEvent<GameRound> onNewGameStarted;
        [SerializeField] private UnityEvent<GameRound> onNewRoundStarted;
        [SerializeField] private SceneReferences references;

        private void Awake()
        {
            StartNewGame();
        }

        private void StartNextRound()
        {
            history.UpdateHistory(CurrentRound);
            CurrentRound = CurrentRound.Next();
            currentTurnPlayer = references.LeftPlayer;
            foreach (var player in references.Units)
                player.OnNewRoundStarted();
            onNewRoundStarted.Invoke(CurrentRound);
        }

        public GameRound CurrentRound { get => current; private set => current = value; }

        /// <summary>
        /// ����� �� ���� ��������� �������� �� �������� ����?
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="senderUnit"></param>
        /// <returns></returns>
        public bool CanUnitPerformAction(LoopActionType action, UnitModel unit)
        {
            if (!unit.Equals(currentTurnPlayer))
                return false;

            if (action == LoopActionType.Attack || action == LoopActionType.ApplyEffect)
            {
                if (!CurrentRound.ContainsActionsOfType(unit, action))
                    return true;
                return false;
            }
            else throw new UnknownEnumValueException<LoopActionType>(action);
        }

        public void OnUnitDead()
        {
            StartNewGame();
        }

        /// <summary>
        /// ������� ����: ��� �������� ����� �����.
        /// ����� ����� �������� ������ �����������, ��� ��������� �������.
        /// ����� ���� ��� ��� ������ ���������, ���������� ����� �����.
        /// </summary>
        public void StartNewGame()
        {
            CurrentRound = new GameRound(1);
            history.ResetValues();
            currentTurnPlayer = references.LeftPlayer;
            foreach (var player in references.Units)
                player.ResetValues();
            onNewGameStarted.Invoke(CurrentRound);
        }

        /// <summary>
        /// ��������� ��������� �������� ����� � ������������ � ����������� ���������.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="action"></param>
        public void UpdateLoop(LoopActionType action, UnitModel unit)
        {
            CurrentRound.ApplyAction(action, unit);
            if (action is LoopActionType.Attack)
            {
                foreach (var player in references.Units)
                {
                    if (player.Health <= 0)
                    {
                        StartNewGame();
                        return;
                    }
                }
                if (unit.Equals(references.LeftPlayer))
                    currentTurnPlayer = references.RightPlayer;
                else
                    StartNextRound();
            }
        }
    }
}