using DunkGame.Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.StateMachine.States
{
    public class IdleState : IStateMachine
    {
        public void OnEnter()
        {
            Debug.Log("Idle Enter");
        }
        public void Action()
        {
            Debug.Log("Idle Action");
        }
        public void OnExit()
        {
            Debug.Log("Idle Exit");
        }
    }
}
