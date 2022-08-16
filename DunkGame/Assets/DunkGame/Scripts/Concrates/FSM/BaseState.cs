using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM
{
    public abstract class BaseState : ScriptableObject
    {
        public abstract void OnEnterExecute(PassableObjectsController passableObjects);
        public abstract void OnMainExecute(PassableObjectsController passableObjects);
        public abstract void OnExitExecute(PassableObjectsController passableObjects);
    }
}
