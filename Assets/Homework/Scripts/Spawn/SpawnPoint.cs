using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [NonSerialized] public Potion Potion;
    public bool IsEmpty => Potion == null;
}
