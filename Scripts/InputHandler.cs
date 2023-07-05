using UnityEngine;
namespace Labirint
{
    public class InputHandler : MonoBehaviour
    {
        /// <summary>
        /// Метод возвращает разницу позиций при свайпе.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetTouchDeltaPosition()
        {
            if (Input.touchCount > 0)
            {
                return Input.GetTouch(0).deltaPosition;
            }
            return Vector2.zero;
        }
        /// <summary>
        /// Метод проверяет было ли касание экрана, возвращает bool.
        /// </summary>
        /// <returns></returns>
        public bool IsThereTouchOnScreen()
        {
            if (Input.touchCount > 0) return true;
            else return false;
        }
    }
}
