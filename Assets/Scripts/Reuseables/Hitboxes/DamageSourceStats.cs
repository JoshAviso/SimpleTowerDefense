using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageSourceStats", menuName = "ScriptableObjects/Damage/DamageSourceStats", order = 1)]
public class DamageSourceStats : ScriptableObject
{
    public EDamageType DamageType;
    public int BasePower;
    public List<DamageEffect> DamageEffects = new();
}
