using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float radius = 2f;
    float areaDamage = 10;

    public void area_damage()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<IDamageable>() != null && hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<IDamageable>().TakeDamage(areaDamage);
                hit.GetComponent<Enemy>().TakeAreaDamage(); // slowdown effect
            }
        }
    }
}
