using DunkGame.Abstracts;
using DunkGame.Concrates.Movement;
using DunkGame.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DunkGame.Concrates.Controllers 
{
    public class BallController : MonoBehaviour
    {
        //Main ball controller.

        IMover mover;
        ParabolaController parabolaController;
        SwipeDetection swipeDetection;

        // This section for getting player inputs to get smooth movement. Can be moved to another script later if wanted.//
        [Header("Getting Inputs")] 
        BaseballInputAction inputAction;
        Vector2 currentInputVector;
        Vector2 smoothInputVelocity;
        float smoothInputSpeed = 0.2f;

        [SerializeField] Collider basketCollider;

        //Timer for colldown between shots.
        float timer = 3f;

        private void Awake()
        {
            mover = new Mover(GetComponent<Rigidbody>());
            inputAction = new BaseballInputAction();
            swipeDetection = SwipeDetection.Instance;
        }
        private void OnEnable()
        {
            inputAction.Enable();
            swipeDetection.OnUpSwipe += ThrowBall;
            swipeDetection.OnRightSwipe += ThrowBall;
            swipeDetection.OnLeftUpSwipe += ThrowBall;
        }
        private void OnDisable()
        {
            inputAction.Disable();
            swipeDetection.OnUpSwipe -= ThrowBall;
            swipeDetection.OnRightSwipe -= ThrowBall;
            swipeDetection.OnLeftUpSwipe -= ThrowBall;
        }
        public Vector2 GetDirection() //Getting direction infos for smooth movement.
        {
            Vector2 input = inputAction.Baseball.Movement.ReadValue<Vector2>();
            currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputSpeed);
            Vector2 direction = new Vector2(currentInputVector.x, currentInputVector.y);
            if (direction.magnitude <= 0.1f)
            {
                return Vector2.zero;
            }
            return direction;
        }
        private void Update()
        {
            timer += Time.deltaTime;
        }
        private void FixedUpdate()
        {
            Movement();
            FallCheck();
        }
        void Movement() // The values got by DetDirection() peform movement here.
        {
            mover.Movement(GetDirection());
        }
        void ThrowBall()
        {
            if (timer > 3f)
            {
                parabolaController = GetComponent<ParabolaController>();
                parabolaController.FollowParabola();
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;

                timer = 0f;
            }
        }
        bool IsBallNearToBasket() // This method make the shot avaible if only close enough to basket. If not can not throw ball. Can be added above if wanted.
        {
           float distance = Vector3.Distance(transform.position, basketCollider.transform.position);
            if (Mathf.Abs(distance) < 15f)
            {
                return true;
            }
            return false;
        }

        void FallCheck() //To prevent ball to fall in void.
        {
            if (transform.position.y < -30)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
