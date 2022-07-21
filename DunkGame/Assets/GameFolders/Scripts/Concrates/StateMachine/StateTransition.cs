using DunkGame.Abstracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DunkGame.Concrates.StateMachine
{
    public class StateTransition
    {
        IStateMachine _from;
        IStateMachine _to;
        System.Func<bool> _condition;
        public IStateMachine From => _from;
        public IStateMachine To => _to;
        public System.Func<bool> Condition => _condition;

        public StateTransition(IStateMachine from, IStateMachine to, Func<bool> condition)
        {
            _from = from;
            _to = to;
            _condition = condition;
        }
    }
}
