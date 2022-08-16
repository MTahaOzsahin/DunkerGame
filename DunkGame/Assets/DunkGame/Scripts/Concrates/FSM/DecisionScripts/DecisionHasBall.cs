using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM.DecisionScripts
{
    [CreateAssetMenu(menuName = "FSM/Decision/HasBall")]
    public class DecisionHasBall : BaseDecision
    {
        public override bool Decide(PassableObjectsController passableObjects)
        {
            return passableObjects.HasBall();
        }
    }
}
