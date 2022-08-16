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

        public override IEnumerator OnEnterExecute(PassableObjectsController passableObjects)
        {
            foreach(var action in actions) action.OnEnterExecute(passableObjects);

            return base.OnEnterExecute(passableObjects);
        }
        public override IEnumerator OnMainExecute(PassableObjectsController passableObjects)
        {
            foreach (var action in actions) action.OnMainExecute(passableObjects);
            foreach (var transition in transitions) transition.Execute(passableObjects);

            return base.OnMainExecute(passableObjects);
        }
        public override IEnumerator OnExitExecute(PassableObjectsController passableObjects)
        {
            foreach (var action in actions) action.OnExitExecute(passableObjects);

            return base.OnExitExecute(passableObjects);
        }
    }
}
