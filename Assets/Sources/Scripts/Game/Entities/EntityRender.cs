using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityRender : MonoBehaviour
{
    public string ColorKey = "_Color_Overlay";
    public Color DefaultColor = Color.white;

    [SerializeField]
    private Renderer[] Renderers;

    private void Awake()
    {
        Renderers.InstantiateMaterials();
    }

    public void SetColor(Color color)
    {
        Renderers.SetColor(ColorKey, color);
    }

    public void ToDefault()
    {
        SetColor(DefaultColor);
    }
}
