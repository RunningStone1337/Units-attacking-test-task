using UnityEngine;

namespace UI
{
    public class ExitButtonHandler : MonoBehaviour
    {
        public void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}