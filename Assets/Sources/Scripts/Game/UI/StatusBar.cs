using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatusBar : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public Image barImage;

    [Space]
    public Color startColor;
    public Color endColor;

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
        targetText.text = Text;
        barImage.fillAmount = FillAmount;

        barImage.color = Color.Lerp(startColor, endColor, FillAmount);
    }

    private void OnDestroy()
    {
        Binding -= RefreshView;
    }
}
