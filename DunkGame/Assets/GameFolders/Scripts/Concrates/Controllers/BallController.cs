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

        // This section for getting player inputs to get smooth movement. Can be moved to another script later if wanted.//
        [Header("Getting Inputs")] 
        BaseballInputAction inputAction;
        Vector2 currentInputVector;
        Vector2 smoothInputVelocity;
        float smoothInputSpeed = 0.2f;



        private void Awake()
        {
            mover = new Mover(GetComponent<Rigidbody>());
            inputAction = new BaseballInputAction();
        }
        private void OnEnable()
        {
            inputAction.Enable();
        }
        private void OnDisable()
        {
            inputAction.Disable();
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
    }
}
