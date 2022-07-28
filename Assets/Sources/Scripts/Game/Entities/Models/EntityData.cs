using UnityEngine;

[System.Serializable]
public class EntityData
{
    public string Name;
    public float StartHealth;
    public float MaxHealth;

    [HideInInspector]
    public float CurrentHealth;

    public float HealthPercent { get => Mathf.Clamp((CurrentHealth / MaxHealth) * 100f, 0f, 100f); }
}
