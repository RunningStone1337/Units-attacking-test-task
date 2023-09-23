using Gameplay;
using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// ���������� UI ������ �������� ������ ����.
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