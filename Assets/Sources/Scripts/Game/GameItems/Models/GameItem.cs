using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameItem : MonoBehaviour
{
    [Header("GameItem")]
    public new Rigidbody rigidbody;
    public new Collider collider;

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
        rigidbody.isKinematic = !enabled;
        collider.enabled = enabled;
    }
}