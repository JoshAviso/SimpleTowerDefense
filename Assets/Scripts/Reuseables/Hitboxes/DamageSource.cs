using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeReference] public DamageSourceStats Stats;
    public GameObject Owner;
    void Awake()
    {
        if (Owner == null) Owner = gameObject;
    }
}
