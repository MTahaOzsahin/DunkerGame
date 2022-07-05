using DunkGame.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace DunkGame.Concrates.Controllers
{
    public class SwipeController : MonoBehaviour
    {
        BaseballInputAction inputAction;
        private void Awake()
        {
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
        private void Start()
        {
        }
    }
}
