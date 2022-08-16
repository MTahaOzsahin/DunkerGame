using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM
{
    [CreateAssetMenu(menuName ="FSM/Transition")]
    public sealed class Transition : ScriptableObject
    {
        public BaseDecision Decision;
        public BaseState TrueState;
        public BaseState FalseState;

        public static event System.Action OnStateChange;
        public void Execute(PassableObjectsController passableObjects)
        {
            if (Decision.Decide(passableObjects))
            {
                passableObjects.NextState = TrueState;
                if (passableObjects.CurrentState != passableObjects.NextState)
                {
                    OnStateChange?.Invoke();
                }
            }
            else
            {
                passableObjects.NextState = FalseState;
                if (passableObjects.CurrentState != passableObjects.NextState)
                {
                    OnStateChange?.Invoke();
                }
            }
        }
    }
}
