using Units;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Обработчик коллбеков на события ввода сцены игрового цикла.
    /// </summary>
    public class UserInputHandler : MonoBehaviour
    {
        [SerializeField] private GameLoop loop;
        [SerializeField] private SceneReferences references;

        public void OnApplyEffectButtonClick(UnitModel senderUnit)
        {
            if (loop.CanUnitPerformAction(LoopActionType.ApplyEffect, senderUnit))//допустимо ли действие правилами игры
            {
                if (senderUnit.TryApplyRandomEffect())//доступно ли действие юниту
                {
                    loop.UpdateLoop(LoopActionType.ApplyEffect, senderUnit);
                }
            }
        }

        public void OnAttackButtonClick(UnitModel senderUnit)
        {
            UnitModel target = references.GetOppositeUnitTo(senderUnit);
            if (loop.CanUnitPerformAction(LoopActionType.Attack, senderUnit))//допустимо ли действие правилами игры
            {
                if (senderUnit.TryAttack(target))//доступно ли действие юниту
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