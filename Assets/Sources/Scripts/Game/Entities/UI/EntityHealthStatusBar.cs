using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealthStatusBar : StatusBar
{
    public Entity Entity;
    protected override string Text => $"{Entity.Health} / {Entity.Data.MaxHealth}";
    protected override float FillAmount => Entity.Data.HealthPercent / 100f;

    public override event Action Binding
    {
        add => Entity.OnChangedHealth += value;
        remove => Entity.OnChangedHealth -= value;
    }
}