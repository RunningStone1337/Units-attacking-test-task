using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

namespace Units
{
    /// <summary>
    /// ¬ьюшка юнита, простой спрайт.
    /// </summary>
    public class UnitView : MonoBehaviour
    {
        [SerializeField] private Color damageColor;
        [SerializeField, HideInInspector] private bool isMethodRunning = false;
        [SerializeField] private SpriteRenderer unitSprite;

        private async Task<float> ChangeColorFixedUpdate(Color from, Color to, float t)
        {
            unitSprite.color = Color.Lerp(from, to, t);
            t += Time.fixedDeltaTime * 1.4f;
            await UniTask.WaitForFixedUpdate();
            return t;
        }

        private async UniTaskVoid OnDamageTakedAsync()
        {
            isMethodRunning = true;
            var cached = unitSprite.color;

            float t = 0;
            while (unitSprite.color != damageColor)
                t = await ChangeColorFixedUpdate(unitSprite.color, damageColor, t);
            t = 0f;
            while (unitSprite.color != cached)
                t = await ChangeColorFixedUpdate(unitSprite.color, cached, t);

            isMethodRunning = false;
        }

        public void OnDamageTaked()
        {
            if (!isMethodRunning)
                OnDamageTakedAsync().Forget();
        }
    }
}