using DunkGame.Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.StateMachine.States
{
    public class ShooterState : IStateMachine
    {
        public void OnEnter()
        {
            Debug.Log("Shooter Enter");
        }
        public void Action()
        {
            Debug.Log("Shooter Action");
        }
        public void OnExit()
        {
            Debug.Log("Shooter Exit");
        }
    }
}
