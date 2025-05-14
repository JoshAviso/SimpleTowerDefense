using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animationTarget;

    public void SetMovement(Vector2 lookDirection, bool isRunning){
        if(lookDirection.sqrMagnitude == 0){
            _animationTarget.SetBool("IsWalking", false);
            _animationTarget.SetBool("IsRunning", false);
            return;
        }

        _animationTarget.SetBool("IsWalking", !isRunning);
        _animationTarget.SetBool("IsRunning", isRunning);

        Vector3 inputAs3D = new(lookDirection.x, 0.0f, lookDirection.y);
        _animationTarget.gameObject.transform.rotation = Quaternion.LookRotation(inputAs3D, Vector3.up);     
    }
}
