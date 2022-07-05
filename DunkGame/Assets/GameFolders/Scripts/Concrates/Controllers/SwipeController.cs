using DunkGame.Abstracts;
using DunkGame.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace DunkGame.Concrates.Controllers
{
    [DefaultExecutionOrder(-1)]
    public class SwipeController : MonoBehaviourSingleton<SwipeController>
    {
        BaseballInputAction inputAction;
        Camera mainCamera;

        public delegate void StartTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch;
        public delegate void EndTouch(Vector2 position, float time);
        public event EndTouch OnEndTouch;

        private void Awake()
        {
            inputAction = new BaseballInputAction();
            mainCamera = Camera.main;
        }
        private void OnEnable()
        {
            inputAction.Enable();
        }
        private void OnDisable()
        {
            inputAction.Disable();
        }
        private void Start()
        {
            inputAction.Baseball.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
            inputAction.Baseball.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        }
        void StartTouchPrimary(InputAction.CallbackContext context)
        {
            //if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(mainCamera, inputAction.Baseball.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
            if (OnStartTouch != null) OnStartTouch(inputAction.Baseball.PrimaryPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
        void EndTouchPrimary(InputAction.CallbackContext context)
        {
            //if (OnEndTouch != null) OnEndTouch(Utils.ScreenToWorld(mainCamera, inputAction.Baseball.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
            if (OnEndTouch != null) OnEndTouch(inputAction.Baseball.PrimaryPosition.ReadValue<Vector2>(), (float)context.time);
        }
        
    }
}
