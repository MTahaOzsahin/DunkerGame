using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class SwipeDetection : MonoBehaviourSingleton<SwipeDetection>
    {
        /* This script made to detect is swipe started and which direction to swipe.
         */

        SwipeController swipeController;
        //How far start and end point must be
        [SerializeField] float minimumDistance = 0.2f;
        //How long start and end time must be
        [SerializeField] float maximumTime = 1f;
        //How close match direction and standard vectors must be. Higher value means sharper swipe.
        [SerializeField,Range(0f,1f)] float directionThreshold = 0.5f;

        Vector2 startPosition;
        float startTime;
        Vector2 endPosition;
        float endTime;

        public event System.Action OnUpSwipe;
        //public event System.Action OnDownSwipe;
        public event System.Action OnRightSwipe;
        public event System.Action OnLeftUpSwipe;


        private void Awake()
        {
            swipeController = SwipeController.Instance;
        }
        private void OnEnable()
        {
            swipeController.OnStartTouch += SwipeStart;
            swipeController.OnEndTouch += SwipeEnd;
        }
        private void OnDisable()
        {
            swipeController.OnStartTouch -= SwipeStart;
            swipeController.OnEndTouch -= SwipeEnd;
        }
        void SwipeStart(Vector2 position,float time)
        {
            startPosition = position;
            startTime = time;
        }
        void SwipeEnd(Vector2 position, float time)
        {
            endPosition = position;
            endTime = time;
            DetectSwipe();
        }
        void DetectSwipe()
        {
            //Check for swipe lenght and duration is enough to perform.
            if (Vector3.Distance(startPosition,endPosition) >= minimumDistance && (endTime - startTime) <= maximumTime)
            {
                Vector3 direction = endPosition - startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(direction2D);
            }
        }

        //Check which direction to swipe.
        void SwipeDirection(Vector2 direction)
        {
            /*Vector 2 Dot
             * returns 1 if given two direction looking same direction 
             * returns 0 if perpendicular to each other
             * returns -1 if opposite direction
             */

            float vector2DotUp = Vector2.Dot(Vector2.up, direction);
            float vector2DotRight = Vector2.Dot(Vector2.right, direction);

            if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
            {
                OnUpSwipe?.Invoke();
                Debug.Log("Swipe up");
            }
            else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
            {
                OnRightSwipe?.Invoke();
                Debug.Log("Swipe Right");
            }
            else if (Vector2.Dot(-Vector2.right, direction) > directionThreshold)
            {
                OnLeftUpSwipe?.Invoke();
                Debug.Log("Swipe Left");
            }
            else if (Vector2.Dot(-Vector2.up, direction) > directionThreshold)
            {
                Debug.Log("Swipe Down");
            }
            //else if (vector2DotUp > 0 && vector2DotUp < directionThreshold && vector2DotRight > 0 && vector2DotRight < directionThreshold)
            //{
            //    Debug.Log("up right cross");
            //}
            //else if (vector2DotUp > 0 && vector2DotUp < directionThreshold && vector2DotRight < 0 && vector2DotRight < directionThreshold)
            //{
            //    Debug.Log("up left cross");
            //}
            //else if (vector2DotUp < 0 && vector2DotUp < directionThreshold && vector2DotRight > 0 && vector2DotRight < directionThreshold)
            //{
            //    Debug.Log("down right cross");
            //}
            //else if (vector2DotUp < 0 && vector2DotUp < directionThreshold && vector2DotRight < 0 && vector2DotRight < directionThreshold)
            //{
            //    Debug.Log("down left cross");
            //}

        }

    }
}
