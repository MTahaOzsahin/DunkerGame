using DunkGame.Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Movement
{
    public class Thrower : IThrower // Will not use.
    {
        [SerializeField] float firingAngle = 45.0f;
        [SerializeField] float gravity = 1.8f;

        void IThrower.SimulateProjectile(Transform transform,Transform basketTransform)
        {
            // Calculate distance to target
            float targetDistance = Vector3.Distance(transform.position, basketTransform.position);

            // Calculate the velocity needed to throw the object to the target at specified angle.
            float ballVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

            // Extract the X  Y componenent of the velocity
            float Vx = Mathf.Sqrt(ballVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
            float Vy = Mathf.Sqrt(ballVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

            // Calculate flight time.
            float flightDuration = targetDistance / Vx;

            // Rotate projectile to face the target.
            transform.rotation = Quaternion.LookRotation(basketTransform.position - transform.position);





            float elapse_time = 0;

            while (elapse_time < flightDuration)
            {
                transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

                elapse_time += Time.deltaTime;
            }
        }
    }
}
