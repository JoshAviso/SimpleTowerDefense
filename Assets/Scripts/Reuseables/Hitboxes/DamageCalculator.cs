using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageCalculator", menuName = "ScriptableObjects/Damage/DamageCalculator", order = 999)]
public class DamageCalculator : ScriptableObject
{
    [Header("Calculation Settings")]
    public float Power_To_Health_Ratio = 0.1f;
    public float Distance_Power_Scalar = 0.0f;
    public bool Type_Effectivity_Stacks = true;
    public EHealingEffectivitySetting Healing_Effectivity = EHealingEffectivitySetting.Does_Not_Use_Effectivity;

    public virtual int CalcDamage(Hurtbox hurtbox, Hitbox hitbox)
    {
        float distScalar = Distance_Power_Scalar * (hitbox.transform.position - hurtbox.transform.position).magnitude;
        return 0;
    }
    public virtual int CalcHealing(Hurtbox hurtbox, Hitbox hitbox)
    {
        return 0;
    }
}

#region Setting Enums
    public enum EHealingEffectivitySetting { Does_Not_Use_Effectivity, Uses_Effectivity, Uses_Effectivity_Stacks, Uses_Only_Positive_Effectivity, Uses_Only_Positive_Effectivity_Stacks }
#endregion