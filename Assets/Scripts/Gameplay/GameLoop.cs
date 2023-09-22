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
        /// ћожет ли юнит выполн€ть действие по услови€м игры
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
        /// ќбновл€ет состо€ние игрового цикла в соответствии с совершенным действием.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="action"></param>
        public void UpdateLoop(LoopActionType action, UnitModel unit)
        {
            history.CurrentRound.ApplyAction(action, unit);
        }
    }
}