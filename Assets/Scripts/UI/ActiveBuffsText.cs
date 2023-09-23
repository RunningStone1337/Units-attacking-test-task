using System.Collections.Generic;
using System.Text;
using TMPro;
using Units;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Контроллер текста активных эффектов юита.
    /// </summary>
    public class ActiveBuffsText : MonoBehaviour
    {
        [SerializeField] private TMP_Text activeEffectsText;
        [SerializeReference] private List<EffectBase> effects = new();

        private void UpdateText()
        {
            var sb = new StringBuilder();
            foreach (var e in effects)
            {
                sb.Append($"{e} ({e.Duration})\n");
            }
            activeEffectsText.text = sb.ToString();
        }

        public void OnEffectAdded(EffectBase effect)
        {
            effects.Add(effect);
            UpdateText();
        }

        public void OnEffectDurationChanged(EffectBase effect)
        {
            UpdateText();
        }

        public void OnEffectRemoved(EffectBase effect)
        {
            effects.Remove(effect);
            UpdateText();
        }
    }
}