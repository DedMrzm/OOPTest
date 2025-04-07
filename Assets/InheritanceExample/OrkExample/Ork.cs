using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ork
{
    public Ork(string name, int health, int damage)
    {
        Name = name;
        Damage = damage;
        Health = health;
    }

    public string Name { get; }
    public int Damage { get; protected set; }
    public int Health { get; protected set; }

    public void TakeDamage(int damage)
    {
        if (Damage < 0)
        {
            Debug.LogError("damage < 0");
            return;
        }
        
        Health -= damage;

        if(Health < 0)
        {
            Health = 0;
        }
            
        
    }
}
