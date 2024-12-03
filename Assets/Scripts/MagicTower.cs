using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicTower : MonoBehaviour, IDamageable
{
    objectPool ObjectPool;
    [SerializeField] Transform magicCreatePoint;
    [SerializeField] SpellSO[] spells;
    [SerializeField] cooldown[] spellButtons;

    [SerializeField] Image healthBar;
    float totalHealth = 100;

    private void Awake()
    {
        ObjectPool = GetComponent<objectPool>();
    }

    List<Enemy> enemies()
    {
        List<Enemy> list = new List<Enemy>();
        var enemies = FindObjectsByType(typeof(Enemy), FindObjectsSortMode.None);

        foreach (Enemy enemy in enemies)
        {
            list.Add(enemy);
        }

        return list;
    }

    public void send_spell(int spell_number)
    {
        if (enemies().Count == 0)
            return;

        if (spells[spell_number].SpellVariables.type == SpellType.Fireball)
        {
            GameObject new_spell = ObjectPool.GetPooledObject(spell_number).gameObject;
            new_spell.transform.position = magicCreatePoint.position;
            new_spell.GetComponent<spell>().variables = spells[spell_number].SpellVariables;
            new_spell.GetComponent<spell>().variables.targetObject = enemies()[Random.Range(0, enemies().Count)].gameObject;
            spellButtons[spell_number].reset_cooldown(spells[spell_number].SpellVariables.cooldownTime);
        }
        else if(spells[spell_number].SpellVariables.type == SpellType.Barrage)
        {
            for (int i = 0; i < enemies().Count; i++)
            {
                GameObject new_spell = ObjectPool.GetPooledObject(spell_number).gameObject;
                new_spell.transform.position = magicCreatePoint.position;
                new_spell.GetComponent<spell>().variables = spells[spell_number].SpellVariables;
                new_spell.GetComponent<spell>().variables.targetObject = enemies()[i].gameObject;
            }
            spellButtons[spell_number].reset_cooldown(spells[spell_number].SpellVariables.cooldownTime);
        }
    }

    public void TakeDamage(float damage)
    {
        totalHealth -= damage;
        refreshHealthBar(totalHealth);

        if(totalHealth <= 0) 
        {
            gameControl.instance.game_over();
        }
    }

    void refreshHealthBar(float health)
    {
        if(health > 0)
            healthBar.fillAmount = health * 0.01f;
        else
            healthBar.fillAmount = 0;
    }
}