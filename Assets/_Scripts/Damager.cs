using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : HealthModifier
{
    [Range(0, 20)]
    public int damage = 10;
    protected override void OnPicked(Collider2D collision)
    {
        base.OnPicked(collision);
        HealthManager healthManager = collision.GetComponent<HealthManager>();
        if (!healthManager) { return; }
        healthManager.Damage(damage);
    }
}
