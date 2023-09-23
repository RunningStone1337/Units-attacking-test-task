using Units;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Предоставляет доступ к ссылкам на объекты сцены игрового цикла.
    /// </summary>
    public class SceneReferences : MonoBehaviour
    {
        [SerializeField] private UnitModel[] units = new UnitModel[2];

        private void Awake()
        {
            ValidateReferences();
        }

        private void ValidateReferences()
        {
            if (LeftPlayer == null)
                throw new UnassignedReferenceException("Assign reference to left player from inspector.");
            if (RightPlayer == null)
                throw new UnassignedReferenceException("Assign reference to right player from inspector.");
        }

        internal UnitModel GetOppositeUnitTo(UnitModel senderUnit)
        {
            if (senderUnit.Equals(LeftPlayer))
                return RightPlayer;
            return LeftPlayer;
        }

        public UnitModel LeftPlayer => units[0];
        public UnitModel RightPlayer => units[1];
        public UnitModel[] Units => units;
    }
}