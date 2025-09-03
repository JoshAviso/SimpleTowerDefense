
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSpecialAction", menuName = "ScriptableObjects/Reuseables/Player/SpecialAction", order = 0)]
public class PlayerSpecialAction : ScriptableObject
{
    public Reuseables.PlayerController.EPlayerAction ActionType = Reuseables.PlayerController.EPlayerAction.None;
    public virtual void Trigger() { Utils.Log("PlayerSpecialAction Trigger function not implemented"); }
}
