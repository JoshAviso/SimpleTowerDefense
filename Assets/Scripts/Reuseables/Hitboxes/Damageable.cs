using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeReference] DamageableStats _stats;
    public GameObject Owner;
    public void TakeDamage(DamageSourceStats damageStats, Vector3 damageVector)
    {

    }

    public void ResetStatus()
    {

    }
    void Awake()
    {
        if (Owner == null) Owner = gameObject;   
    }
}
