using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class PassController : MonoBehaviourSingleton<PassController>
    {
        /// <summary>
        /// This script controls that which objects can be passed and objects positions.
        /// Passable objects must be child of a gameobject that containing this script.
        /// </summary>

        List<Transform> gameobjectsToPasss = new List<Transform>();

        [Header("Ball Transform")]
        [SerializeField] Transform ballTransform;

        private void Start()
        {
            foreach (Transform obj in GetComponentsInChildren<Transform>())
            {
                if (obj.parent != null) //To not get this gameobject's transform since GetComponentsInChildren takes parents component's too.
                {
                    gameobjectsToPasss.Add(obj);
                }
            }
        }
        
        /// <summary>
        /// Checking between of the preset passable objects that which is the closest in the right side of ball.
        /// </summary>
        public Transform CheckClosestRight()
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = ballTransform.position;
            
            foreach (Transform obj in gameobjectsToPasss)
            {
                float dist = Vector3.Distance(obj.position, currentPos);
                if (dist < minDist)
                {
                    if (3f < dist) // To avoid to pass current passable object.
                    {
                        if (ballTransform.position.z > obj.position.z ) // To make sure this is right side.
                        {
                            tMin = obj;
                            minDist = dist;
                        }
                    }
                }
            }
            return tMin;
        }
        /// <summary>
        /// Checking between of the preset passable objects that which is the closest in the left side of ball.
        /// </summary>
        public Transform CheckClosestLeft()
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = ballTransform.position;

            foreach (Transform obj in gameobjectsToPasss)
            {
                float dist = Vector3.Distance(obj.position, currentPos);
                if (dist < minDist)
                {
                    if (3f < dist) // To avoid to pass current passable object.
                    {
                        if (ballTransform.position.z < obj.position.z) // To make sure this is left side.
                        {
                            tMin = obj;
                            minDist = dist;
                        }
                    }
                }
            }
            return tMin;
        }
    }
}
