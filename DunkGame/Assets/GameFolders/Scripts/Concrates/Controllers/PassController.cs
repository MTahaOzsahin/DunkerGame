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
        //Transform CheckClosestRight()
        //{
        //    foreach (Transform obj in objectsToPasss)
        //    {
        //        Vector3 closestTransform = Vector3.(ballTransform.position, obj.position);
        //    }
        //    return closestTransform
        //}
        void CheckClosestLeft()
        {

        }
    }
}
