using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameItem : MonoBehaviour
{
    [Header("GameItem")]
    public Rigidbody Rigidbody;
    public Collider Collider;

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public Quaternion Rotation
    {
        get => transform.rotation;
        set => transform.rotation = value;
    }

    public abstract void Action();

    public virtual void SetPhysics(bool enabled)
    {
        Rigidbody.isKinematic = !enabled;
        Collider.enabled = enabled;
    }
}