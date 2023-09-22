using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace Gameplay
{
    public class UserInputHandler : MonoBehaviour
    {
        [SerializeField] GameLoop loop;
        [SerializeField] SceneReferences references;
        public void OnAttackButtonClick(UnitModel senderUnit)
        {
             UnitModel target = references.GetOppositeUnitTo(senderUnit);
            if (loop.CanUnitPerformAction(LoopActionType.Attack, senderUnit))//��������� �� �������� ��������� ����
            {
                if (senderUnit.TryAttack(target))//�������� �� �������� �����
                {
                    loop.UpdateLoop(LoopActionType.Attack, target);
                }
            }
        }
        public void OnApplyButtonClick(UnitModel senderUnit)
        {
            if (loop.CanUnitPerformAction(LoopActionType.ApplyBuff, senderUnit))//��������� �� �������� ��������� ����
            {
                if (senderUnit.TryApplyRandomBuff())//�������� �� �������� �����
                {
                    loop.UpdateLoop(LoopActionType.ApplyBuff, senderUnit);
                }
            }
        }
    }
}