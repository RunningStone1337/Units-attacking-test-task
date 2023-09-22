using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class RoundsHistory
    {
        [SerializeField] GameRound current;
        public GameRound CurrentRound { get => current; private set=> current = value; }
    }
}