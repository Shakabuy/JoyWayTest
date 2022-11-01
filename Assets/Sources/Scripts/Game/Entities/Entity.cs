using System;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public EntityData data;
    public EntityRender render;
    public EntityAnimator animator;
    public StatusEffectControl statusEffectControl;

    public event Action OnChangedHealth;
    public event Action<DamageInfo> OnDamage;

    public float Health
    {
        get => data.CurrentHealth;
        set
        {
            if (data.CurrentHealth == value) { return; }
            data.CurrentHealth = value;
            OnChangedHealth?.Invoke();
        }
    }

    private void Awake()
    {
        Health = data.StartHealth;
        animator.Init(this);
        statusEffectControl.Init(this);
    }

    public void Damage(DamageInfo damageInfo)
    {
        if(Health > 0)
        {
            statusEffectControl.CheckDamage(ref damageInfo);

            Health -= damageInfo.Amount;

            OnDamage?.Invoke(damageInfo);

            if (Health <= 0)
            {
                Health = 0;
                Kill();
            }
        }
    }

    public void Resurrect()
    {
        Health = data.MaxHealth;
        gameObject.SetActive(true);
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
