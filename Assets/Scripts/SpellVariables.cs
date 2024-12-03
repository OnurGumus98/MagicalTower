using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpellVariables
{
    public int ID;
    public SpellType type;
    public GameObject spellPrefab;
    public GameObject impactPrefab;
    public float speed;
    public float damage;
    public float cooldownTime;
    public GameObject targetObject;
}