using DunkGame.Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Movement
{
    public class Mover : IMover
    {
        Rigidbody _rigidbody;
        float movementSpeed = 15f;
        float throwPower = 500f;
        public Mover(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void ThrowBall(Vector3 dif) // Will not use
        {
            _rigidbody.velocity = Vector3.zero; 
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.AddForce(dif * throwPower);
        }

        public void Movement(Vector2 direction)
        {
            _rigidbody.velocity = new Vector3(direction.y * movementSpeed, _rigidbody.velocity.y, direction.x * -movementSpeed);
        }
    }
}
