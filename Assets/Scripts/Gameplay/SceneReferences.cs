using Units;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Предоставляет доступ к ссылкам на объекты сцены игрового цикла.
    /// </summary>
    public class SceneReferences : MonoBehaviour
    {
        [SerializeField] UnitModel leftPlayer;
        [SerializeField] UnitModel rightPlayer;
        private void Awake()
        {
            ValidateReferences();
        }
        private void ValidateReferences()
        {
            if (leftPlayer == null)
                throw new UnassignedReferenceException("Assign reference to left player from inspector.");
            if (rightPlayer == null)
                throw new UnassignedReferenceException("Assign reference to right player from inspector.");
        }

        internal UnitModel GetOppositeUnitTo(UnitModel senderUnit)
        {
            if (senderUnit.Equals(leftPlayer))
                return rightPlayer;
            return leftPlayer;
        }
    }
}