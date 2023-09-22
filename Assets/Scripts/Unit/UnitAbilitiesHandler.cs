using Gameplay;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Units
{
    [Serializable]
    public class UnitAbilitiesHandler : UnitComponentBase, IResetable
    {
        [SerializeReference] EffectBase[] unitActiveAbilities = new EffectBase[2];
        [SerializeField] UnityEvent<EffectBase> onAbilityRemoved;
        public UnitAbilitiesHandler(UnitModel thisUnit, params EffectBase[] abilitiesMax2) : base(thisUnit)
        {
            if (abilitiesMax2.Length > 2)
                throw new ArgumentException("Unit can't has more then 2 active abilities once at time");
            for (int i = 0; i < abilitiesMax2.Length; i++)
            {
                unitActiveAbilities[i] = abilitiesMax2[i];
            }
        }

        public void ResetValues()
        {
            for (int i = 0; i < unitActiveAbilities.Length; i++)
            {
                var tempAbil = unitActiveAbilities[i];
                if (tempAbil != null)
                {
                    onAbilityRemoved.Invoke(tempAbil);
                    unitActiveAbilities[i] = null;
                }
            }
        }

        public bool TryApplyRandomBuff()
        {
            throw new NotImplementedException();
        }

        public void ApplyAttackEffects(UnitModel target)
        {
            for (int i = 0; i < unitActiveAbilities.Length; i++)
            {
                var tEffect = unitActiveAbilities[i];
                if (tEffect is IAttackMomentEffect cast)
                {
                    cast.ApplyEffectTo(target);
                }
            }
        }
    }
}