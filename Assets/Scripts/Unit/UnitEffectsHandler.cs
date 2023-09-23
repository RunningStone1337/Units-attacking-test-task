using Gameplay;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Units
{
    /// <summary>
    /// Обработчик подсистемы управления эффектами юнита
    /// </summary>
    [Serializable]
    public class UnitEffectsHandler : UnitComponentBase, IResetable
    {
        [SerializeField] private EffectFactoryMethod[] effectsFactories = new EffectFactoryMethod[5];
        [SerializeField, Range(1, 10)] private int maxRoundsDuration = 5;
        [SerializeReference] private EffectBase[] unitActiveEffects = new EffectBase[2];

        #region events

        [SerializeField] private UnityEvent<EffectBase> onEffectAdded;
        [SerializeField] private UnityEvent<EffectBase> onEffectDurationChanged;
        [SerializeField] private UnityEvent<EffectBase> onEffectRemoved;

        #endregion events

        private void ApplyEffect(EffectBase effect)
        {
            if (effect is IAdditionTimeEffect self)
                self.ApplyEffect();
            for (int i = 0; i < unitActiveEffects.Length; i++)
            {
                if (unitActiveEffects[i] == null)
                {
                    unitActiveEffects[i] = effect;
                    onEffectAdded.Invoke(effect);
                    break;
                }
            }
        }

        private bool ContainsSameEffect(EffectBase effect)
        {
            for (int i = 0; i < unitActiveEffects.Length; i++)
            {
                var t = unitActiveEffects[i];
                if (t != null)
                    if (t.GetType().Equals(effect.GetType()))
                        return true;
            }
            return default;
        }

        private bool MaxEffectsCountApplied()
        {
            return unitActiveEffects.Where(x => x != null).Count() == 2;
        }

        private void RemoveEffect(EffectBase effect)
        {
            if (effect == null)
                return;

            if (effect is IAdditionTimeEffect cast)
                cast.RemoveEffect();

            for (int i = 0; i < unitActiveEffects.Length; i++)
            {
                var tEffect = unitActiveEffects[i];
                if (effect.Equals(tEffect))
                {
                    unitActiveEffects[i] = default;
                    break;
                }
            }
        }

        public UnitEffectsHandler(UnitModel thisUnit, params EffectBase[] abilitiesMax2) : base(thisUnit)
        {
            if (abilitiesMax2.Length > 2)
                throw new ArgumentException("Unit can't has more then 2 active abilities once at time");
            for (int i = 0; i < abilitiesMax2.Length; i++)
            {
                unitActiveEffects[i] = abilitiesMax2[i];
            }
        }

        public void ApplyAttackEffects(UnitModel target)
        {
            for (int i = 0; i < unitActiveEffects.Length; i++)
            {
                var tEffect = unitActiveEffects[i];
                if (tEffect is IAttackMomentEffect cast)
                {
                    cast.ApplyEffectTo(target);
                }
            }
        }

        public void OnNewRoundStarted()
        {
            for (int i = 0; i < unitActiveEffects.Length; i++)
            {
                var tEffect = unitActiveEffects[i];
                if (tEffect != null)
                {
                    tEffect.Duration--;
                    onEffectDurationChanged.Invoke(tEffect);
                    if (tEffect.Duration == 0)
                    {
                        RemoveEffect(tEffect);
                        onEffectRemoved.Invoke(tEffect);
                    }
                }
            }
        }

        public void ResetValues()
        {
            for (int i = 0; i < unitActiveEffects.Length; i++)
            {
                var tempAbil = unitActiveEffects[i];
                if (tempAbil != null)
                {
                    onEffectRemoved.Invoke(tempAbil);
                    unitActiveEffects[i] = null;
                }
            }
        }

        /// <summary>
        /// Если есть доступный для применения эффект, применяет его, иначе ничего не делает.
        /// </summary>
        /// <returns></returns>
        public bool TryApplyRandomEffect()
        {
            if (MaxEffectsCountApplied())
                return default;

            //очередь индексов фабрик, от которых в случайном порядке будем получать очередной эффект пока там есть непроверенные
            var indexes = Enumerable.Range(0, effectsFactories.Length).Shuffle();
            while (indexes.Count > 0)
            {
                var effect = effectsFactories[indexes.Dequeue()].CreateEffect(unit, Random.Range(1, maxRoundsDuration));
                if (!ContainsSameEffect(effect))
                {
                    ApplyEffect(effect);
                    return true;
                }
            }
            return default;
        }
    }
}