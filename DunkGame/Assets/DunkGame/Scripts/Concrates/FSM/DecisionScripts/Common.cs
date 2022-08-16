using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.FSM.DecisionScripts
{
    [CreateAssetMenu(menuName ="FSM/Decison/Common")]
    public class Common : BaseDecision
    {
        public override bool Decide(PassableObjectsController passableObjects)
        {
            return true;
        }
    }
}
