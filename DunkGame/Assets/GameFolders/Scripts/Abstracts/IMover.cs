using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Abstracts
{
    public interface IMover
    {
        void Movement(Vector2 direction);
        void ThrowBall(Vector3 dif);
    }
}
