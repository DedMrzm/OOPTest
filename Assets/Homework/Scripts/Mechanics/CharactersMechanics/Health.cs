using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value;

    public int Value
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
