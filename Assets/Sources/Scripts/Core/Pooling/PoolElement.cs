using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolElement : MonoBehaviour
{
    public virtual void InitPoolElement(IPool pool)
    {
        _pool = pool;
    }

    [HideInInspector]
    public bool isInPool;
    protected IPool _pool;

    protected virtual void ReturnToPool()
    {
        _pool.ReturnToPool(this);
    }
}