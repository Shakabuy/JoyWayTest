using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Animator animator;

    [Space]
    public string damageEffectKey = "damage_effect";
    private Entity _entity;
    public void Init(Entity entity)
    {
        _entity = entity;
        _entity.OnDamage += OnDamageCallback;
    }

    private void OnDamageCallback(DamageInfo damageInfo)
    {
        if(damageInfo.Amount == 0) { return; }
        animator.Play(damageEffectKey);
    }

    private void OnDestroy()
    {
        _entity.OnDamage -= OnDamageCallback;
    }
}
