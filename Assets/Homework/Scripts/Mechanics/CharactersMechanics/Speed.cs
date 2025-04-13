using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] private float _value;

    public float Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (_value < 0)
                _value = 0;
            else
                _value = value;
        }
    }
}
