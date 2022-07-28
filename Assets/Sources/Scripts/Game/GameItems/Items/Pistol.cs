using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GameItem
{
    [Header("Pistol")]
    public DamageInfo DamageInfo;
    public float Distance;
    public Transform OutputBarrel;

    public override void Action()
    {
        Ray ray = new Ray(OutputBarrel.position, transform.forward);
        Damager.RayDamage(DamageInfo, ray, Distance);
    }
}
