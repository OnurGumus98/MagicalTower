using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public SpellVariables variables;
    pooledObject pooledObject;

    private void Awake()
    {
        if(variables.type == SpellType.Fireball)
            gameObject.AddComponent<Fireball>();

        pooledObject = GetComponent<pooledObject>();
    }

    private void FixedUpdate()
    {
        if (variables.targetObject != null)
            transform.position = Vector3.MoveTowards(transform.position, variables.targetObject.transform.position, Time.deltaTime * variables.speed);
        else
            pooledObject.Release();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IDamageable>() != null && other.gameObject == variables.targetObject)
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(variables.damage);
            Instantiate(variables.impactPrefab, transform.position, Quaternion.identity);

            if (variables.type == SpellType.Fireball)
                GetComponent<Fireball>().area_damage();

            pooledObject.Release();
        }
    }
}
