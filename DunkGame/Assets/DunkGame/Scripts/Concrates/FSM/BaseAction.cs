using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM
{
    public abstract class BaseAction : ScriptableObject
    {
        public abstract IEnumerator OnEnterExecute(PassableObjectsController passableObjects);
        public abstract IEnumerator OnMainExecute(PassableObjectsController passableObjects);
        public abstract IEnumerator OnExitExecute(PassableObjectsController passableObjects);
    }
}
