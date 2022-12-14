using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class EntityNameText : MonoBehaviour
{
    public Entity Entity;
    public TextMeshProUGUI Text;

    private void Awake()
    {
        Text.text = Entity.data.Name;
    }

    private void Reset()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
}