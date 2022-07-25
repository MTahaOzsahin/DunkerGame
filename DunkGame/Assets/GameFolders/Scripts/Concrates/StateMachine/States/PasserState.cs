using DunkGame.Abstracts;
using DunkGame.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.StateMachine.States
{
    public class PasserState : IStateMachine
    {
        /// <summary>
        /// This state means passer player. Passer player will keep distance in a radius to ball.
        /// </summary>
        IEntityController _entityController;
        Transform _ballTransform;

        Vector3 targetPosition;
        float distanceToBall;
        
        public PasserState(IEntityController entityController,Transform ballTransform)
        {
            _entityController = entityController;
            _ballTransform = ballTransform;
        }

        public void OnEnter()
        {

        }
        public void Action()
        {
            float radius = 5f; 
            Vector3 originPosition = _ballTransform.localPosition; 
            distanceToBall = Vector3.Distance(_entityController.transform.position, _ballTransform.position);
            if (distanceToBall > radius) 
            {
                Vector3 fromOriginToTarget = new Vector3(targetPosition.x - originPosition.x,0f,targetPosition.z - originPosition.z); 
                fromOriginToTarget *= radius / distanceToBall; 
                targetPosition = originPosition + fromOriginToTarget; 
                _entityController.transform.position = new Vector3(targetPosition.x ,_entityController.transform.position.y,targetPosition.z);
            }
        }
        public void OnExit()
        {

        }
    }
}
