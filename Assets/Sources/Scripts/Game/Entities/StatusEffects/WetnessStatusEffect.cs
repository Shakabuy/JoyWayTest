using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetnessStatusEffect : StatusEffect
{
    [Header("Wetness")]
    public float maxPoints = 100f;
    public Color color = Color.blue;

    public event Action OnChangedPoints;

    private float _points;
    public float Points
    {
        get => _points;
        set
        {
            if(_points == value) { return; }
            _points = Mathf.Clamp(value, 0, maxPoints);

            if(_points == 0)
            {
                Deactivate();
            }

            OnChangedPoints?.Invoke();
        }
    }
    public float PointsPercent { get => Mathf.Clamp((Points / maxPoints) * 100f, 0f, 100f); }

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
        Entity.render.SetColor(color);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Entity.render.ToDefault();
    }

    public override void UpdateState(float dt)
    {
    }
}
