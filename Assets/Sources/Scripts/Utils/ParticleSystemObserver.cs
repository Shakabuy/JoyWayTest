using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemObserver : MonoBehaviour
{
    public event Action<GameObject> OnParticleCollisionEvent;
    private void OnParticleCollision(GameObject other)
    {
        OnParticleCollisionEvent?.Invoke(other);
    }
}
