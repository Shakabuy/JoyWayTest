using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RendererExtensions
{
    public static void SetEnabled(this Renderer[] renderers, bool isEnabled)
    {
        foreach (var renderer in renderers)
        {
            renderer.enabled = isEnabled;
        }
    }

    public static void InstantiateMaterials(this Renderer[] renderers)
    {
        foreach (var renderer in renderers)
        {
            InstantiateMaterials(renderer);
        }
    }

    public static void InstantiateMaterials(this Renderer renderer)
    {
        for (int i = 0; i < renderer.materials.Length; i++)
        {
            renderer.materials[i] = GameObject.Instantiate(renderer.materials[i]);
        }
    }

    public static void SetColor(this Renderer[] renderers, string key, Color value)
    {
        foreach (var renderer in renderers)
        {
            SetColor(renderer, key, value);
        }
    }

    public static void SetColor(this Renderer renderer, string key, Color value)
    {
        for (int i = 0; i < renderer.materials.Length; i++)
        {
            renderer.materials[i].SetColor(key, value);
        }
    }
}
