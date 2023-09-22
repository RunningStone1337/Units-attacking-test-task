using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace Gameplay
{
    public enum LoopActionType
    {
        Attack,
        ApplyBuff
    }
    public class GameLoop : MonoBehaviour
    {
     
        [SerializeField] RoundsHistory history = new();

        /// <summary>
        /// ����� �� ���� ��������� �������� �� �������� ����
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="senderUnit"></param>
        /// <returns></returns>
        public bool CanUnitPerformAction(LoopActionType action, UnitModel unit)
        {
            if (action == LoopActionType.Attack || action == LoopActionType.ApplyBuff)
            {
                if (!history.CurrentRound.ContainsActionsOfType(unit, action))
                    return true;
                return false;
            }
            else throw new UnknownEnumValueException<LoopActionType>(action);
        }

        /// <summary>
        /// ��������� ��������� �������� ����� � ������������ � ����������� ���������.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="action"></param>
        public void UpdateLoop(LoopActionType action, UnitModel unit)
        {
            history.CurrentRound.ApplyAction(action, unit);
        }
    }
}