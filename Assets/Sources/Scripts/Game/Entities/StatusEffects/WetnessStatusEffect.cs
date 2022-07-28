using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetnessStatusEffect : StatusEffect
{
    [Header("Wetness")]
    public float MaxPoints = 100f;
    public Color Color = Color.blue;

    public event Action OnChangedPoints;

    private float points;
    public float Points
    {
        get => points;
        set
        {
            if(points == value) { return; }
            points = Mathf.Clamp(value, 0, MaxPoints);

            if(points == 0)
            {
                Deactivate();
            }

            OnChangedPoints?.Invoke();
        }
    }
    public float PointsPercent { get => Mathf.Clamp((Points / MaxPoints) * 100f, 0f, 100f); }

    public override void CheckDamage(ref DamageInfo damageInfo)
    {
        switch (damageInfo.Type)
        {
            case DamageType.Standard:
                base.CheckDamage(ref damageInfo);
                break;

            case DamageType.Incendiary:
                Points -= damageInfo.Amount;
                damageInfo.Amount = 0;
                break;

            case DamageType.Water:
                Points += damageInfo.Amount;
                damageInfo.Amount = 0;
                break;
        }
    }

    public override void Activate()
    {
        base.Activate();
        Entity.Render.SetColor(Color);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Entity.Render.ToDefault();
    }

    public override void UpdateState(float dt)
    {
    }
}
