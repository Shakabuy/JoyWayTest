using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetnessStatusBar : StatusBar
{
    public WetnessStatusEffect WetnessStatusEffect;
    protected override string Text => $"{WetnessStatusEffect.Points} / {WetnessStatusEffect.MaxPoints}";
    protected override float FillAmount => WetnessStatusEffect.PointsPercent / 100f;

    public override event Action Binding
    {
        add => WetnessStatusEffect.OnChangedPoints += value;
        remove => WetnessStatusEffect.OnChangedPoints -= value;
    }
}
