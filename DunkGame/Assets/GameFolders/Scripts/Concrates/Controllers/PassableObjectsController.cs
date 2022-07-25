
using DunkGame.Abstracts;
using DunkGame.Concrates.StateMachine;
using DunkGame.Concrates.StateMachine.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class PassableObjectsController : MonoBehaviour ,IEntityController ,IPlayerType
    {
        StatesMachine _statesMachine;

        [SerializeField] IPlayerType.PlayerType playerType;

        [SerializeField] Transform ballTransform;

        bool isPasser = false;
        bool isShooter = false;
        bool isIdle = false;

        private void Awake()
        {
            _statesMachine = new StatesMachine();
        }
        private void Start()
        {
            SetPlayerType();

            IdleState idleState = new IdleState();
            PasserState passerState = new PasserState(this,ballTransform);
            ShooterState shooterState = new ShooterState();

            _statesMachine.AddAnyTransition(idleState, () => isIdle);
            _statesMachine.AddAnyTransition(shooterState, () => isShooter);
            _statesMachine.AddAnyTransition(passerState, () => isPasser);

            _statesMachine.SetState(idleState);
        }
        private void Update()
        {
            _statesMachine.Action();
        }
        void SetPlayerType()
        {
            if (playerType == IPlayerType.PlayerType.Idle)
            {
                isIdle = true;
            }
            else if (playerType == IPlayerType.PlayerType.Shooter)
            {
                isShooter = true;
            }
            else if (playerType == IPlayerType.PlayerType.Passer)
            {
                isPasser = true;
            }
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
