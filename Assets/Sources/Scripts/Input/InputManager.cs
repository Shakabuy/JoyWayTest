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

    private static bool isInit = false;

    private static Vector2 mouseAxis;
    private static Vector2 movementAxis;
    private static void Init()
    {
        if (isInit)
        {
            return;
        }

        GameObject obj = new GameObject("InputUpdater");
        GameObject.DontDestroyOnLoad(obj);

        var updater = obj.AddComponent<InputUpdater>();

        updater.OnUpdateCallback += UpdateCallback;

        isInit = true;
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

        mouseAxis.x = Input.GetAxis("Mouse X");
        mouseAxis.y = Input.GetAxis("Mouse Y");

        movementAxis.x = Input.GetAxis("Horizontal");
        movementAxis.y = Input.GetAxis("Vertical");
    }

    public static Vector2 GetMouseAxis()
    {
        return mouseAxis;
    }

    public static Vector2 GetMovementAxis()
    {
        return movementAxis;
    }
}
