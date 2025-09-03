

using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [Header("Settings")]
    [SerializeReference] private DamageableStats _stats;
    [SerializeField] private EHitboxLayer _hurtLayer;

#region Callbacks
    [Header("Callbacks")]
    [SerializeField] private UnityEvent<int> _onHit;
    [SerializeField] private UnityEvent<int> _onDeath;
    [SerializeField] private UnityEvent<int> _onHeal;
    [SerializeField] private UnityEvent<int> _onRevive;
#endregion

    public void ResetStatus()
    {

    }

    #region Hit processing
    public void ProcessHit(Hitbox source, Hurtbox hurtbox)
    {
        if ((source.Source.Stats.DamageType & _stats.Healing) != 0)
            HealDamage(source, hurtbox);
        else TakeDamage(source, hurtbox);
    }
    private void TakeDamage(Hitbox source, Hurtbox hurtbox)
    {
        // bool 
    }
    private void HealDamage(Hitbox source, Hurtbox hurtbox)
    {
        
    }
#endregion
#region Setup
    public EHitboxLayer HurtLayer => _hurtLayer;
    void Start()
    {
        if (_stats == null)
        {
            Utils.LogWarning(this, "Damageable must have stats.");
            Destroy(this);
            return;
        }
    } 
#endregion
}
