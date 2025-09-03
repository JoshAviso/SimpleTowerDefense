using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [Header("Settings")]
    [SerializeReference] private DamageSourceStats _stats;
    [SerializeField] private EHitboxLayer _targetLayers;


    public DamageSourceStats Stats => _stats;
    public EHitboxLayer TargetLayers => _targetLayers;
    void Start(){ if (_stats == null) Destroy(this); }
}
