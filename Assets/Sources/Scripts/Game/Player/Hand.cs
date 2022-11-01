using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float dropForce = 1f;
    private GameItem _currentItem;

    public bool HasItem => _currentItem != null;

    private void LateUpdate()
    {
        if (!HasItem) { return; }

        _currentItem.Position = transform.position;
        _currentItem.Rotation = transform.rotation;
    }

    public void Action()
    {
        _currentItem.Action();
    }

    public void Drop()
    {
        _currentItem.SetPhysics(true);
        _currentItem.rigidbody.AddForce(transform.forward * dropForce, ForceMode.VelocityChange);
        _currentItem.rigidbody.AddRelativeTorque(Random.insideUnitSphere * dropForce, ForceMode.VelocityChange);
        _currentItem = null;
    }

    public void Equip(GameItem item)
    {
        _currentItem = item;
        _currentItem.SetPhysics(false);
    }
}
