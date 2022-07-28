using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatusBar : MonoBehaviour
{
    public TextMeshProUGUI TMProText;
    public Image Bar;

    [Space]
    public Color StartColor;
    public Color EndColor;

    public abstract event Action Binding;

    protected abstract string Text { get; }
    protected abstract float FillAmount { get; }

    protected virtual void Start()
    {
        RefreshView();
        Binding += RefreshView;
    }

    protected virtual void RefreshView()
    {
        TMProText.text = Text;
        Bar.fillAmount = FillAmount;

        Bar.color = Color.Lerp(StartColor, EndColor, FillAmount);
    }

    private void OnDestroy()
    {
        Binding -= RefreshView;
    }
}
