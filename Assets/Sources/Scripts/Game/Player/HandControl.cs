using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public Hand leftHand;
    public Hand rightHand;

    [Header("For Raycasting")]
    public new Camera camera;
    public float distance;


    private void Awake()
    {
        InputManager.OnActionLeft += Action_Left;
        InputManager.OnActionRight += Action_Right;
        InputManager.OnEquipLeft += FindItem_Left;
        InputManager.OnEquipRight += FindItem_Right;
    }

    public void Action_Left()
    {
        ActionHand(leftHand);
    }
    public void Action_Right()
    {
        ActionHand(rightHand);
    }
    public void FindItem_Left()
    {
        FindItem(leftHand);
    }
    public void FindItem_Right()
    {
        FindItem(rightHand);
    }

    private void FindItem(Hand hand)
    {
        if (hand.HasItem)
        {
            hand.Drop();
        }

        if (Physics.Raycast(camera.GetRay(), out var hit, distance))
        {
            if (hit.collider.TryGetComponent<GameItem>(out var item))
            {
                hand.Equip(item);
            }
        }
    }

    private void ActionHand(Hand hand)
    {
        if (hand.HasItem)
        {
            hand.Action();
        }
    }

    private void OnDestroy()
    {
        InputManager.OnActionLeft -= Action_Left;
        InputManager.OnActionRight -= Action_Right;
        InputManager.OnEquipLeft -= FindItem_Left;
        InputManager.OnEquipRight -= FindItem_Right;
    }
}