using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Abstracts
{
    public interface IMover
    {
        void Movement(Vector2 direction);
        void ThrowBallRigibody(Vector3 dif);
    }
}
