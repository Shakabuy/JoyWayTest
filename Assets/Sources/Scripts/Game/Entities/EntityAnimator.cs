using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Animator Animator;

    [Space]
    public string DamageEffectKey = "damage_effect";
    private Entity Entity;
    public void Init(Entity entity)
    {
        Entity = entity;
        Entity.OnDamage += OnDamageCallback;
    }

    private void OnDamageCallback(DamageInfo damageInfo)
    {
        if(damageInfo.Amount == 0) { return; }
        Animator.Play(DamageEffectKey);
    }

    private void OnDestroy()
    {
        Entity.OnDamage -= OnDamageCallback;
    }
}
