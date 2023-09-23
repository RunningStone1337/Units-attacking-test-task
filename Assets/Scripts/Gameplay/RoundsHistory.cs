using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// История игровой сессии по ранудам.
    /// </summary>
    [Serializable]
    public class RoundsHistory : IResetable
    {
        [SerializeField] private List<GameRound> roundsHistory = new();

        public void ResetValues()
        {
            roundsHistory.Clear();
        }

        public void UpdateHistory(GameRound currentRound)
        {
            roundsHistory.Add(currentRound);
        }
    }
}