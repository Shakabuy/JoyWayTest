using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetnessStatusBar : StatusBar
{
    public WetnessStatusEffect wetnessStatusEffect;
    protected override string Text => $"{wetnessStatusEffect.Points} / {wetnessStatusEffect.maxPoints}";
    protected override float FillAmount => wetnessStatusEffect.PointsPercent / 100f;

    public override event Action Binding
    {
        add => wetnessStatusEffect.OnChangedPoints += value;
        remove => wetnessStatusEffect.OnChangedPoints -= value;
    }
}
