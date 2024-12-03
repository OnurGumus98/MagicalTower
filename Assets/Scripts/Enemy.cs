using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyVariables variables;
    float firstSpeed;
    bool is_slowed_down;

    void Start()
    {
        firstSpeed = variables.speed;
    }

    public void TakeDamage(float damage)
    {
        variables.health -= damage;

        if(variables.health <= 0)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, variables.target.position, Time.deltaTime * variables.speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Enemies colliders are not touching each other because of their layers
        if(!gameControl.is_game_over && other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(variables.damage);
            Destroy(gameObject);
        }
    }

    public void TakeAreaDamage() // slow down
    {
        is_slowed_down = true;
        variables.speed = 0;
    }

    void Update()
    {
        if (!is_slowed_down)
            return;

        if(variables.speed <= firstSpeed)
        {
            variables.speed += Time.deltaTime;
        }
        else
        {
            variables.speed = firstSpeed;
            is_slowed_down = false;
        }
    }
}