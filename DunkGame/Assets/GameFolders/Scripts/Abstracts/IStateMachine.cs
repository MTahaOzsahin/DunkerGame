using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Abstracts
{
    public interface IStateMachine
    {
        void OnEnter();
        void Action();
        void OnExit();
    }
}
