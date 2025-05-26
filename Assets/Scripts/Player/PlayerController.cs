using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeReference] private PlayerStats _playerStats;

    #region References
    private PlayerAnimator _animator;
    private PlayerControls _controls;
    private Rigidbody _rigidBody;
    #endregion

    #region State
    private float _currentSpeedMod = 1.0f;
    #endregion

    void Awake()
    {
        _controls = new();
    }

    void Start()
    {
        Utils.TryGetComponentNullCheck(this, out _animator, "No animator detected");
        Utils.TryGetComponentNullCheck(this, out _rigidBody, "No rigidbody detected");
    }

    void OnEnable()
    {
        _controls.Actions.Enable();
    }

    void FixedUpdate()
    {
        CheckPlayerInput();
    }

    private void CheckPlayerInput(){
        MovePlayer(
            _controls.Actions.Movement.ReadValue<Vector2>(), 
            _controls.Actions.Run.IsPressed());
    }

    private void MovePlayer(Vector2 moveInput, bool isRunning){
        moveInput.Normalize();
        if(moveInput.sqrMagnitude == 0.0f){
            _animator.SetMovement(Vector2.zero, false);
            return;
        }

        _animator.SetMovement(moveInput, isRunning);

        Vector3 inputAs3D = new(moveInput.x, 0.0f, moveInput.y);

        if(isRunning)   _rigidBody.MovePosition(_rigidBody.position + _playerStats.BaseRunSpeed *_currentSpeedMod * Time.fixedDeltaTime * inputAs3D);
        else            _rigidBody.MovePosition(_rigidBody.position + _playerStats.BaseWalkSpeed *_currentSpeedMod * Time.fixedDeltaTime * inputAs3D);
    }
}
