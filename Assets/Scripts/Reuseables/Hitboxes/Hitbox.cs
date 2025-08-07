using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Hitbox : MonoBehaviour
{
    public DamageSource Source;
    void OnTriggerEnter(Collider other) { ProcessHit(other.gameObject); }
    void OnCollisionEnter(Collision collision) { ProcessHit(collision.gameObject); }
    private void ProcessHit(GameObject other)
    {
        if (!other.TryGetComponent<Hurtbox>(out Hurtbox hurtbox)) return;
        if (Source.Owner == hurtbox.Owner.Owner) return;
        hurtbox.ProcessHit(this);
    }
    void Start()
    {
        if (Source == null) Destroy(this);
    }

}
