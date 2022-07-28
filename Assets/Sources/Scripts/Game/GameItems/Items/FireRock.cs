using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRock : GameItem
{
    [Header("FireRock")]
    public DamageInfo DamageInfo;
    public ParticleSystem ParticleSystem;
    public ParticleSystemObserver ParticleSystemObserver;

    private void Awake()
    {
        ParticleSystemObserver.OnParticleCollisionEvent += OnParticleCollisionCallback;
    }

    public override void Action()
    {
        ParticleSystem.Play();
    }

    private void OnParticleCollisionCallback(GameObject other)
    {
        Damager.GameObjectDamage(DamageInfo, other);
    }

    private void OnDestroy()
    {
        ParticleSystemObserver.OnParticleCollisionEvent -= OnParticleCollisionCallback;
    }
}
