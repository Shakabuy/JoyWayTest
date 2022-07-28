using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : PoolElement
{
    public float LifeTime = 3f;
    public DamageInfo DamageInfo;
    public Rigidbody Rigidbody;

    public void Throw(Vector3 startPosition, Vector3 force)
    {
        ResetPhycics();

        transform.position = startPosition;
        Rigidbody.AddForce(force, ForceMode.VelocityChange);

        StopAllCoroutines();
        StartCoroutine(LifeCycleCoroutine());
    }

    IEnumerator LifeCycleCoroutine()
    {
        yield return new WaitForSeconds(LifeTime);
        ReturnToPool();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damager.GameObjectDamage(DamageInfo, collision.gameObject);
        ReturnToPool();
    }

    private void ResetPhycics()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
    }

    protected override void ReturnToPool()
    {
        StopAllCoroutines();
        ResetPhycics();

        base.ReturnToPool();
    }
}