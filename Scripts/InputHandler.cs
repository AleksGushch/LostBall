using UnityEngine;
namespace Labirint
{
    public class InputHandler : MonoBehaviour
    {
        /// <summary>
        /// ����� ���������� ������� ������� ��� ������.
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
        /// ����� ��������� ���� �� ������� ������, ���������� bool.
        /// </summary>
        /// <returns></returns>
        public bool IsThereTouchOnScreen()
        {
            if (Input.touchCount > 0) return true;
            else return false;
        }
    }
}
