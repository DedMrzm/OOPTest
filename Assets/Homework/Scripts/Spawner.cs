using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Potion> _potions;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            spawnPoint.Potion = GetRandomPotion();
        }
    }

    private Potion GetRandomPotion() => _potions[Random.Range(0, _potions.Count - 1)];
}
