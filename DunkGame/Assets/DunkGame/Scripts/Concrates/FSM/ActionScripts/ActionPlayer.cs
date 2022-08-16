using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM.ActionScripts
{
    [CreateAssetMenu(menuName ="FSM/Actions/Player")]
    public class ActionPlayer : BaseAction
    {
        public override void OnEnterExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("Player Enter");
        }

        public override void OnExitExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("Player Exit");
        }

        public override void OnMainExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("Player Main");
        }
    }
}
