using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Abstracts
{
    public interface IThrower
    {
        void SimulateProjectile(Transform transform, Transform basketTransform);
    }
}
