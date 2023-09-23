using Gameplay;
using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Обработчик UI текста текущего раунда игры.
    /// </summary>
    public class CurrentRoundTextHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentRoundText;

        public void OnNewRoundStarted(GameRound newRound)
        {
            currentRoundText.text = $"Round: {newRound.Number}";
        }
    }
}