using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Potion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    

    private void Update()
    {
        
    }

    public virtual void Use()
    {
        _particleSystem.Play();
        Destroy(this);
    }

}
