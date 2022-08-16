using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM
{
    public abstract class BaseDecision : ScriptableObject
    {
        public abstract bool Decide(PassableObjectsController passableObjects);
    }
}
