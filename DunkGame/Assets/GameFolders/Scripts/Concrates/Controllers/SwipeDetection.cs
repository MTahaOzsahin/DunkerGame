using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class SwipeDetection : MonoBehaviourSingleton<SwipeDetection>
    {
        SwipeController swipeController;

        [SerializeField] float minimumDistance = 0.2f;
        [SerializeField] float maximumTime = 1f;
        [SerializeField,Range(0f,1f)] float directionThreshold = 0.5f;

        Vector2 startPosition;
        float startTime;
        Vector2 endPosition;
        float endTime;


        public delegate void SwipeDetected();
        public event SwipeDetected OnSwipe;

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
            DetechSwipe();
        }
        void DetechSwipe()
        {
            if (Vector3.Distance(startPosition,endPosition) >= minimumDistance && (endTime - startTime) <= maximumTime)
            {
                Debug.DrawLine(startPosition, endPosition, Color.red,5f);
                Vector3 direction = endPosition - startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(direction2D);
            }
        }
        void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.up,direction) > directionThreshold)
            {
                OnSwipe?.Invoke();
            }
        }

    }
}
