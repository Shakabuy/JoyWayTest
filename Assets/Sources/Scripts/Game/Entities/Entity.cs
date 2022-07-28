using System;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public EntityData Data;
    public EntityRender Render;
    public EntityAnimator Animator;
    public StatusEffectControl StatusEffectControl;

    public event Action OnChangedHealth;
    public event Action<DamageInfo> OnDamage;

    public float Health
    {
        get => Data.CurrentHealth;
        set
        {
            if (Data.CurrentHealth == value) { return; }
            Data.CurrentHealth = value;
            OnChangedHealth?.Invoke();
        }
    }

    private void Awake()
    {
        Health = Data.StartHealth;
        Animator.Init(this);
        StatusEffectControl.Init(this);
    }

    public void Damage(DamageInfo damageInfo)
    {
        if(Health > 0)
        {
            StatusEffectControl.CheckDamage(ref damageInfo);

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
        Health = Data.MaxHealth;
        gameObject.SetActive(true);
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
