using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Damager
{
    public static void RayDamage(DamageInfo damageInfo, Ray ray, float distance)
    {
        if (Physics.Raycast(ray, out var hit, distance))
        {
            RaycastHitDamage(damageInfo, hit, hit.point - ray.origin);
        }
    }

    public static void RaycastHitDamage(DamageInfo damageInfo, RaycastHit hit, Vector3 direction)
    {
        if (hit.collider.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.Damage(damageInfo);
        }
    }

    public static void GameObjectDamage(DamageInfo damageInfo, GameObject gameObject)
    {
        if (gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.Damage(damageInfo);
        }
    }
}
