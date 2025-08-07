using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Hurtbox : MonoBehaviour
{
    public Damageable Owner;
    public void ProcessHit(Hitbox source)
    {
        
    }
    void Start()
    {
        if (Owner == null) Destroy(this);   
    }
}
