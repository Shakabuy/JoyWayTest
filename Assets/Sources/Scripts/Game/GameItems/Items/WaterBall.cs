using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : PoolElement
{
    public float lifeTime = 3f;
    public DamageInfo damageInfo;
    public new Rigidbody rigidbody;

    public void Throw(Vector3 startPosition, Vector3 force)
    {
        ResetPhycics();

        transform.position = startPosition;
        rigidbody.AddForce(force, ForceMode.VelocityChange);

        StopAllCoroutines();
        StartCoroutine(LifeCycleCoroutine());
    }

    IEnumerator LifeCycleCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        ReturnToPool();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damager.GameObjectDamage(damageInfo, collision.gameObject);
        ReturnToPool();
    }

    private void ResetPhycics()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    protected override void ReturnToPool()
    {
        StopAllCoroutines();
        ResetPhycics();

        base.ReturnToPool();
    }
}