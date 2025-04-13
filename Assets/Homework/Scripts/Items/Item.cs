using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystemPrefab;
    public virtual void Use(GameObject owner)
    {
        ParticleSystem particleSystemTemp = Instantiate(_particleSystemPrefab, transform.position, Quaternion.identity);

        particleSystemTemp.Play();

        Destroy(gameObject);
        Destroy(particleSystemTemp, particleSystemTemp.main.duration);
    }

    public abstract bool CanUse(GameObject owner);

    public void HideMesh()
        => GetComponentInChildren<MeshRenderer>().gameObject.SetActive(false);

}
