using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public sealed class State : BaseState
    {
        public List<BaseAction> actions = new List<BaseAction>();
        public List<Transition> transitions = new List<Transition>();

        public override void OnEnterExecute(PassableObjectsController passableObjects)
        {
            foreach (var action in actions) action.OnEnterExecute(passableObjects);
        }
        public override void OnMainExecute(PassableObjectsController passableObjects)
        {
            foreach (var transition in transitions) transition.Execute(passableObjects);
            foreach (var action in actions) action.OnMainExecute(passableObjects);
        }
        public override void OnExitExecute(PassableObjectsController passableObjects)
        {
            foreach (var action in actions) action.OnExitExecute(passableObjects);
        }
    }
}
