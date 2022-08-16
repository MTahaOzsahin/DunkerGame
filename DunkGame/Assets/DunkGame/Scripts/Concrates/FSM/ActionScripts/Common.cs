using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM.ActionScripts
{
    [CreateAssetMenu(menuName ="FSM/Actions/Common")]
    public class Common : BaseAction
    {
        public override IEnumerator OnEnterExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("on enter");
            yield return new WaitForEndOfFrame();
        }

        public override IEnumerator OnExitExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("on exit");
            yield return new WaitForEndOfFrame();
        }
        public override IEnumerator OnMainExecute(PassableObjectsController passableObjects)
        {
            Debug.Log("on main");
            yield break;
        }
    }
}
