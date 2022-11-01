using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    static InputManager()
    {
        Init();
    }

    //Hands
    public static event Action OnEquipLeft;
    public static event Action OnEquipRight;
    public static event Action OnActionLeft;
    public static event Action OnActionRight;

    //Debug
    public static event Action OnDebug;

    private static bool _isInit = false;

    private static Vector2 _mouseAxis;
    private static Vector2 _movementAxis;
    private static void Init()
    {
        if (_isInit)
        {
            return;
        }

        GameObject obj = new GameObject("InputUpdater");
        GameObject.DontDestroyOnLoad(obj);

        var updater = obj.AddComponent<InputUpdater>();

        updater.OnUpdateCallback += UpdateCallback;

        _isInit = true;
    }

    private static void UpdateCallback()
    {
        //Mouse

        if (Input.GetMouseButtonDown(0))
        {
            OnActionLeft?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnActionRight?.Invoke();
        }


        //Keyboard

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnEquipLeft?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnEquipRight?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            OnDebug?.Invoke();
        }

        //Axis

        _mouseAxis.x = Input.GetAxis("Mouse X");
        _mouseAxis.y = Input.GetAxis("Mouse Y");

        _movementAxis.x = Input.GetAxis("Horizontal");
        _movementAxis.y = Input.GetAxis("Vertical");
    }

    public static Vector2 GetMouseAxis()
    {
        return _mouseAxis;
    }

    public static Vector2 GetMovementAxis()
    {
        return _movementAxis;
    }
}
