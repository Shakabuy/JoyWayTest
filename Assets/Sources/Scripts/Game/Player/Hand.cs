using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float DropForce = 1f;
    private GameItem CurrentItem;

    public bool HasItem => CurrentItem != null;

    private void LateUpdate()
    {
        if (!HasItem) { return; }

        CurrentItem.Position = transform.position;
        CurrentItem.Rotation = transform.rotation;
    }

    public void Action()
    {
        CurrentItem.Action();
    }

    public void Drop()
    {
        CurrentItem.SetPhysics(true);
        CurrentItem.Rigidbody.AddForce(transform.forward * DropForce, ForceMode.VelocityChange);
        CurrentItem.Rigidbody.AddRelativeTorque(Random.insideUnitSphere * DropForce, ForceMode.VelocityChange);
        CurrentItem = null;
    }

    public void Equip(GameItem item)
    {
        CurrentItem = item;
        CurrentItem.SetPhysics(false);
    }
}
