using System;
using UnityEngine;

public class InputUpdater : MonoBehaviour
{
    public event Action OnUpdateCallback;

    private void Update()
    {
        OnUpdateCallback?.Invoke();
    }
}