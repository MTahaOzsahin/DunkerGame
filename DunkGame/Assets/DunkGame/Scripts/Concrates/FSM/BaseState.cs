using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual IEnumerator OnEnterExecute(PassableObjectsController passableObjects) { yield return passableObjects; }
        public virtual IEnumerator OnMainExecute(PassableObjectsController passableObjects) { yield return passableObjects; }
        public virtual IEnumerator OnExitExecute(PassableObjectsController passableObjects) {yield return passableObjects; }
    }
}
