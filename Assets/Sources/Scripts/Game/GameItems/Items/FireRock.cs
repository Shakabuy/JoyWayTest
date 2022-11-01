using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRock : GameItem
{
    [Header("FireRock")]
    public DamageInfo damageInfo;
    public new ParticleSystem particleSystem;
    public ParticleSystemObserver particleSystemObserver;

    private void Awake()
    {
        particleSystemObserver.OnParticleCollisionEvent += OnParticleCollisionCallback;
    }

    public override void Action()
    {
        particleSystem.Play();
    }

    private void OnParticleCollisionCallback(GameObject other)
    {
        Damager.GameObjectDamage(damageInfo, other);
    }

    private void OnDestroy()
    {
        particleSystemObserver.OnParticleCollisionEvent -= OnParticleCollisionCallback;
    }
}
