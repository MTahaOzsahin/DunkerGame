using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM.DecisionScripts
{
    [CreateAssetMenu(menuName ="FSM/Decision/True")]
    public class DecisionTrue : BaseDecision
    {
        public override bool Decide(PassableObjectsController passableObjects)
        {
            return true;
        }
    }
}
