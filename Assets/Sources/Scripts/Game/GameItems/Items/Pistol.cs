using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GameItem
{
    [Header("Pistol")]
    public DamageInfo damageInfo;
    public float distance;
    public Transform outputBarrel;

    public override void Action()
    {
        Ray ray = new Ray(outputBarrel.position, transform.forward);
        Damager.RayDamage(damageInfo, ray, distance);
    }
}
