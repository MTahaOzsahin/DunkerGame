using DunkGame.Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Movement
{
    public class Mover : IMover
    {
        Rigidbody _rigidbody;
        float movementSpeed = 5f;
        public Mover(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
        void IMover.Movement(Vector2 direction)
        {
            //if (direction == Vector2.zero)
            //{
            //    _rigidbody.velocity = new Vector3(0f,-9.8f,0f);
            //}
            _rigidbody.velocity = new Vector3(direction.y * movementSpeed, _rigidbody.velocity.y, direction.x * -movementSpeed);
        }
    }
}
