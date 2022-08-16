
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

        [SerializeField] Transform ballTransform;

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
