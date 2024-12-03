using UnityEngine;

[System.Serializable]
public struct EnemyVariables
{
    public EnemyType type;
    public GameObject enemyPrefab;
    public float health;
    public Transform target;
    public float speed;
    public float damage;
}