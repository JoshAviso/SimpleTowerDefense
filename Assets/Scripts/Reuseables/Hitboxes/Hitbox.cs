using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Hitbox : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private DamageSource _source;
    [SerializeField] private EHitboxLayer _whitelistTargetLayers;
    [SerializeField] private EHitboxLayer _blacklistTargetLayers;

    // ===================================================== //

#region Public Helpers
    public DamageSource Source => _source;
    public EHitboxLayer TargetLayers =>
        (_source.TargetLayers | _whitelistTargetLayers) & ~_blacklistTargetLayers;
#endregion
#region Trigger Hit
void OnTriggerEnter(Collider other) { ProcessHit(other.gameObject); }
private void ProcessHit(GameObject other)
{ if (other.TryGetComponent<Hurtbox>(out Hurtbox hurtbox)) hurtbox.ProcessHit(this); }
#endregion
#region Setup
    void Start()
    {
        if (_source == null)
            _source = GetComponentInParent<DamageSource>();
        if (_source == null)
        {
            Utils.LogWarning(this, "Hitbox must be assigned a DamageSource or have a parent DamageSource.");
            Destroy(this);
            return;
        }

        bool hasTriggerCollider = false;
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider collider in colliders)
            if (collider.isTrigger) { hasTriggerCollider = true; break; }

        if (!hasTriggerCollider)
        {
            Utils.LogWarning(this, "Hitbox must have a trigger collider.");
            Destroy(this);
            return;
        }
    }
    #endregion
}
