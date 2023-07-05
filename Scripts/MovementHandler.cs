using UnityEngine;
namespace Labirint
{
    public class MovementHandler : MonoBehaviour
    {
        public InputHandler inputHandler;
        [SerializeField] private float ballSpeed = 0.2f;
        [SerializeField] private Rigidbody rb;

        void Start()
        {
            if (inputHandler == null) Debug.LogError("Назначить Input Handler");
        }
        /// <summary>
        /// Метод перемещает шар за счет изменения глобальных параметров гравитации по направлению свайпа
        /// </summary>
        private void MoveBall()
        {
            if (inputHandler.IsThereTouchOnScreen())
            {
                Vector2 currDeltaPosition = inputHandler.GetTouchDeltaPosition();
                currDeltaPosition *= ballSpeed;
                Vector3 newGravityVector = new Vector3(currDeltaPosition.x, Physics.gravity.y, currDeltaPosition.y);
                Physics.gravity = newGravityVector;
            }
        }
        /// <summary>
        /// Метод задает силу для перемещения шара в направлении свайпа.
        /// </summary>
        private void MoveBallAddForce()
        {
            if (inputHandler.IsThereTouchOnScreen())
            {
                Vector2 currDeltaPosition = inputHandler.GetTouchDeltaPosition();
                Vector3 directionVector = new Vector3(currDeltaPosition.normalized.x, 0, currDeltaPosition.normalized.y);
                rb.AddForce(directionVector * ballSpeed);
            }
        }
        void FixedUpdate()
        {
            //MoveBall();
            MoveBallAddForce();
        }

    }
}
