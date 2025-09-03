
using UnityEngine;

public class DamageEffect : ScriptableObject
{
    public virtual void ApplyEffect(Hitbox source, Hurtbox target, float power)
    { Utils.Log(source, $"Using the effect of {name} with {power} power, still unimplemented." ); }
}
