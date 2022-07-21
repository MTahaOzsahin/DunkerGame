
using DunkGame.Abstracts;
using DunkGame.Concrates.StateMachine;
using DunkGame.Concrates.StateMachine.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class PassableObjectsController : MonoBehaviour ,IEntityController
    {
        StatesMachine _statesMachine;

        private void Awake()
        {
            _statesMachine = new StatesMachine();
        }
        private void Start()
        {
            IdleState idleState = new IdleState();

            _statesMachine.SetState(idleState);
        }
        private void Update()
        {
            _statesMachine.Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BallController>() != null)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<BallController>() != null)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
