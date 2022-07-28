using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolElement : MonoBehaviour
{
    public virtual void InitPoolElement(IPool pool)
    {
        Pool = pool;
    }

    [HideInInspector]
    public bool IsInPool;
    protected IPool Pool;

    protected virtual void ReturnToPool()
    {
        Pool.ReturnToPool(this);
    }
}