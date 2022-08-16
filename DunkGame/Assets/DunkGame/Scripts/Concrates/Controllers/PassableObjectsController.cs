
using DunkGame.Abstracts;
using DunkGame.Concrates.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class PassableObjectsController : MonoBehaviour ,IEntityController
    {
        [SerializeField] BaseState initialState;
        [HideInInspector] public BaseState PreviousState;
        [HideInInspector] public BaseState CurrentState;
        [HideInInspector] public BaseState NextState;

        public enum ObjectType { friendlyPasser, friendlyShooter,enemyBlocker}
        public ObjectType objectType;


        bool hasBall = false;
        private void OnEnable()
        {
            Transition.OnStateChange += OnStateChange;
        }
        private void OnDisable()
        {
            Transition.OnStateChange -= OnStateChange;
        }
        private void Awake()
        {
            CurrentState = initialState;
        }
        private void Start()
        {
            CurrentState.OnEnterExecute(this);
        }
        private void Update()
        {
            CurrentState.OnMainExecute(this);
        }
        void OnStateChange()
        {
            CurrentState.OnExitExecute(this);
            NextState.OnEnterExecute(this);
            CurrentState = NextState;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BallController>() != null)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                hasBall = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<BallController>() != null)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                hasBall = false;
            }
        }
        public bool HasBall()
        {
            return hasBall;
        }
    }
}
