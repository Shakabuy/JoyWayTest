using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public Hand LeftHand;
    public Hand RightHand;

    [Header("For Raycasting")]
    public Camera Camera;
    public float Distance;


    private void Awake()
    {
        InputManager.OnActionLeft += Action_Left;
        InputManager.OnActionRight += Action_Right;
        InputManager.OnEquipLeft += FindItem_Left;
        InputManager.OnEquipRight += FindItem_Right;
    }

    public void Action_Left()
    {
        ActionHand(LeftHand);
    }
    public void Action_Right()
    {
        ActionHand(RightHand);
    }
    public void FindItem_Left()
    {
        FindItem(LeftHand);
    }
    public void FindItem_Right()
    {
        FindItem(RightHand);
    }

    private void FindItem(Hand hand)
    {
        if (hand.HasItem)
        {
            hand.Drop();
        }

        if (Physics.Raycast(Camera.GetRay(), out var hit, Distance))
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