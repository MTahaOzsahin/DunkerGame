using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class PassController : MonoBehaviour
    {
        /// <summary>
        /// This script controls that which objects can be passed and objects positions.
        /// </summary>

        List<Transform> objectsToPasss = new List<Transform>();

        [Header("Start Position")]
        [SerializeField] Transform ballTransform;

        private void Start()
        {
            objectsToPasss.Add(ballTransform);
            foreach (GameObject gameObjectsToPass in GameObject.FindGameObjectsWithTag("ObjectsToPass"))
            {
                objectsToPasss.Add(gameObjectsToPass.transform);
            }
        }
        private void Update()
        {
            CheckClosestRight();
            CheckClosestLeft();
        }

        public Transform CheckClosestRight()
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = ballTransform.position;
            
            foreach (Transform obj in objectsToPasss)
            {
                float dist = Vector3.Distance(obj.position, currentPos);
                if (dist < minDist)
                {
                    if (3f < dist)
                    {
                        if (ballTransform.position.z > obj.position.z )
                        {
                            tMin = obj;
                            minDist = dist;
                        }
                    }
                }
            }
            Debug.Log("Closesst right " + tMin.name);
            return tMin;
        }
        public Transform CheckClosestLeft()
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = ballTransform.position;

            foreach (Transform obj in objectsToPasss)
            {
                float dist = Vector3.Distance(obj.position, currentPos);
                if (dist < minDist)
                {
                    if (3f < dist)
                    {
                        if (ballTransform.position.z < obj.position.z)
                        {
                            tMin = obj;
                            minDist = dist;
                        }
                    }
                }
            }
            Debug.Log("Closesst left " + tMin.name);
            return tMin;
        }
    }
}
