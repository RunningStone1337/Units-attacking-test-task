using Units;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// ���������� ��������� �� ������� ����� ����� �������� �����.
    /// </summary>
    public class UserInputHandler : MonoBehaviour
    {
        [SerializeField] private GameLoop loop;
        [SerializeField] private SceneReferences references;

        public void OnApplyEffectButtonClick(UnitModel senderUnit)
        {
            if (loop.CanUnitPerformAction(LoopActionType.ApplyEffect, senderUnit))//��������� �� �������� ��������� ����
            {
                if (senderUnit.TryApplyRandomEffect())//�������� �� �������� �����
                {
                    loop.UpdateLoop(LoopActionType.ApplyEffect, senderUnit);
                }
            }
        }

        public void OnAttackButtonClick(UnitModel senderUnit)
        {
            UnitModel target = references.GetOppositeUnitTo(senderUnit);
            if (loop.CanUnitPerformAction(LoopActionType.Attack, senderUnit))//��������� �� �������� ��������� ����
            {
                if (senderUnit.TryAttack(target))//�������� �� �������� �����
                {
                    loop.UpdateLoop(LoopActionType.Attack, senderUnit);
                }
            }
        }

        public void OnRestartButtonClick()
        {
            loop.StartNewGame();
        }
    }
}