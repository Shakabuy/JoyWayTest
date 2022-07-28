using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityResurrectDebug : MonoBehaviour
{
    private void Awake()
    {
        InputManager.OnDebug += ResurrectAll;
    }

    public void ResurrectAll()
    {
        FindObjectsOfType<Entity>(true).ForEach(entity => entity.Resurrect());
    }

    private void OnDestroy()
    {
        InputManager.OnDebug -= ResurrectAll;
    }
}
