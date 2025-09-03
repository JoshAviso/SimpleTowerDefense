using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageableStats", menuName = "ScriptableObjects/Damage/DamageableStats", order = 0)]
public class DamageableStats : ScriptableObject
{
    public EDamageType Weaknesses = EDamageType.None;
    public EDamageType Resistances = EDamageType.None;
    public EDamageType NullDamage = EDamageType.None;
    public EDamageType IgnoresResist = EDamageType.Critical;
    public EDamageType Healing = EDamageType.Healing;

}
