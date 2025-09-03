
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Hurtbox : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private EHitboxLayer _hurtboxLayer;

    // ======================================================== //

#region Helper
    public bool ProcessHit(Hitbox source)
    {
        if ((source.TargetLayers & _hurtLayer) == 0) return false;

        _owner.ProcessHit(source, this);
        return true;
    }
    private EHitboxLayer _hurtLayer => _hurtboxLayer | _owner.HurtLayer;

#endregion
#region Setup
    private Damageable _owner;
    void Start()
    {
        _owner = GetComponentInParent<Damageable>();
        if (_owner == null)
        {
            Utils.LogWarning(this, "Hurtbox must have damageable parent.");
            Destroy(this);
            return;
        }

        bool hasTriggerCollider = false;
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider collider in colliders)
            if (collider.isTrigger) { hasTriggerCollider = true; break; }

        if (!hasTriggerCollider)
        {
            Utils.LogWarning(this, "Hurtbox must have a trigger collider.");
            Destroy(this);
            return;
        }

    }
#endregion
}
