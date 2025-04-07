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
        if (!_particleSystem.isPlaying)
        {
            _particleSystem.Play();
            Debug.Log("Use");
            Destroy(gameObject, _particleSystem.main.duration);
        }
    }

    public void HideMyMesh()
        => GetComponentInChildren<MeshRenderer>().gameObject.SetActive(false);

}
