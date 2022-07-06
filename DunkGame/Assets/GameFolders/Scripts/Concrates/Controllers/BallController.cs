using DunkGame.Abstracts;
using DunkGame.Concrates.Movement;
using DunkGame.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers 
{
    public class BallController : MonoBehaviour
    {
        IMover mover;
        IThrower thrower;

        SwipeDetection swipeDetection;

        // This section for getting player inputs to get smooth movement. Can be moved to another script later if wanted.//
        [Header("Getting Inputs")] 
        BaseballInputAction inputAction;
        Vector2 currentInputVector;
        Vector2 smoothInputVelocity;
        float smoothInputSpeed = 0.2f;

        [SerializeField] Collider basketCollider;

        private void Awake()
        {
            mover = new Mover(GetComponent<Rigidbody>());
            thrower = new Thrower();
            inputAction = new BaseballInputAction();
            swipeDetection = SwipeDetection.Instance;
        }
        private void OnEnable()
        {
            inputAction.Enable();
            swipeDetection.OnSwipe += ThrowBall;
        }
        private void OnDisable()
        {
            inputAction.Disable();
            swipeDetection.OnSwipe -= ThrowBall;
        }
        public Vector2 GetDirection()
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
        private void FixedUpdate()
        {
            Movement();
        }
        void Movement()
        {
            mover.Movement(GetDirection());
        }
        void ThrowBall()
        {
            //Vector3 shoot = (basketCollider.transform.position - transform.position).normalized;
            //mover.ThrowBall(shoot);

            thrower.SimulateProjectile(transform, basketCollider.transform);

        }
    }
}
