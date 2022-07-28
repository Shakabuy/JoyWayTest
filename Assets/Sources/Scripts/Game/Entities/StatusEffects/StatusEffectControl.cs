using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusEffectControl : MonoBehaviour
{
    public List<StatusEffect> StatusEffects = new List<StatusEffect>();

    public void Init(Entity entity)
    {
        foreach (var statusEffect in StatusEffects)
        {
            statusEffect.Init(entity);
        }
    }

    public void CheckDamage(ref DamageInfo damageInfo)
    {
        switch (damageInfo.Type)
        {
            case DamageType.Standard: break;
            case DamageType.Incendiary:
                if (HasActive(StatusEffectType.Water) == false)
                {
                    Activate(StatusEffectType.Fire);
                }
                break;

            case DamageType.Water:
                if (HasActive(StatusEffectType.Fire))
                {
                    Deactivate(StatusEffectType.Fire);
                }
                Activate(StatusEffectType.Water);
                break;
        }

        foreach (var statusEffect in StatusEffects)
        {
            if (statusEffect.IsActive)
            {
                statusEffect.CheckDamage(ref damageInfo);
            }
        }
    }

    private bool HasActive(StatusEffectType type)
    {
        return StatusEffects.Any(x => x.IsActive && x.Type == type);
    }

    private void Activate(StatusEffectType type)
    {
        StatusEffects.Where(x => x.Type == type).ForEach(x => x.Activate());
    }

    private void Deactivate(StatusEffectType type)
    {
        StatusEffects.Where(x => x.Type == type).ForEach(x => x.Deactivate());
    }

    private void Update()
    {
        StatusEffects.Where(x => x.IsActive).ForEach(x => x.UpdateState(Time.deltaTime));
    }
}
