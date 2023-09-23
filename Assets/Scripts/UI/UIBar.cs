using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Обработчик UI прогресс-бара.
    /// </summary>
    public class UIBar : MonoBehaviour
    {
        [SerializeField] private Image barFiller;
        [SerializeField] private TMP_Text barText;

        public void UpdateBar(int value, int maxValue)
        {
            barFiller.fillAmount = (float)value / maxValue;
            barText.text = $"{value}/{maxValue}";
        }
    }
}