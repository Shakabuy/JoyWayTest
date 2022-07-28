using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    public float DamageMultiplier = 1f;
    public StatusEffectType Type;

    [HideInInspector]
    public Entity Entity;

    [HideInInspector]
    public bool IsActive;

    public virtual void Init(Entity entity)
    {
        Entity = entity;
    }

    public virtual void CheckDamage(ref DamageInfo damageInfo)
    {
        if (damageInfo.Type == DamageType.Standard)
        {
            damageInfo.Amount *= DamageMultiplier;
        }
    }

    public abstract void UpdateState(float dt);

    public virtual void Activate()
    {
        IsActive = true;
    }

    public virtual void Deactivate()
    {
        IsActive = false;
    }
}
