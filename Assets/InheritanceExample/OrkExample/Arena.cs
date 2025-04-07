using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    private void Start()
    {
        OrkPaladin orkPaladin = new OrkPaladin(10, "Орк-паладин", 35, 5);
        OrkMage orkMage = new OrkMage(2, "Орк-маг", 20, 10);

        ProcessBattle(orkMage, orkPaladin);

        DetermineWinner(orkMage, orkPaladin);
    }

    private void ProcessBattle(OrkMage orkMage, OrkPaladin orkPaladin)
    {
        while (orkPaladin.Health > 0 && orkMage.Health > 0)
        {
            orkMage.CastSpell();
            orkPaladin.TakeDamage(orkMage.Damage);

            orkPaladin.Heal();
            orkMage.TakeDamage(orkPaladin.Damage);

            Debug.Log($"{orkPaladin.Name} - {orkPaladin.Health}");
            Debug.Log($"{orkMage.Name} - {orkMage.Health}");
        }
    }


    private void DetermineWinner(OrkMage orkMage, OrkPaladin orkPaladin)
    {
        if (orkPaladin.Health <= 0 && orkMage.Health <= 0)
        {
            Debug.Log("Ничья");
        }
        else if (orkMage.Health > 0)
            Debug.Log($"Победил {orkMage.Name}");
        else if (orkPaladin.Health > 0)
            Debug.Log($"Победил {orkPaladin.Name}");

    }
}
