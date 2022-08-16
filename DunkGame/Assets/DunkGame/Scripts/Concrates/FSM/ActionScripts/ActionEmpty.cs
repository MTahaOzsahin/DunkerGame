using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM.ActionScripts
{
    [CreateAssetMenu(menuName ="FSM/Actions/Empty")]
    public class ActionEmpty : BaseAction
    {
        public override void OnEnterExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("Empty enter");
        }

        public override void OnExitExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("Empty exit");
        }
        public override void OnMainExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("Empty main");
        }
    }
}
