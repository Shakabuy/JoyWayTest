using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityRender : MonoBehaviour
{
    public string colorKey = "_Color_Overlay";
    public Color defaultColor = Color.white;

    [SerializeField] private Renderer[] renderers;

    private void Awake()
    {
        renderers.InstantiateMaterials();
    }

    public void SetColor(Color color)
    {
        renderers.SetColor(colorKey, color);
    }

    public void ToDefault()
    {
        SetColor(defaultColor);
    }
}
