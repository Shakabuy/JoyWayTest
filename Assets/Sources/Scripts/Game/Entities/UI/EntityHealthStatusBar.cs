using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealthStatusBar : StatusBar
{
    public Entity entity;
    protected override string Text => $"{entity.Health} / {entity.data.MaxHealth}";
    protected override float FillAmount => entity.data.HealthPercent / 100f;

    public override event Action Binding
    {
        add => entity.OnChangedHealth += value;
        remove => entity.OnChangedHealth -= value;
    }
}