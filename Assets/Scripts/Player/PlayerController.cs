using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    private PlayerAnimator _animator;
    private PlayerControls _controls;

    void Awake()
    {
        _controls = new();
    }

    void Start()
    {
        Utils.TryGetComponentNullCheck(this, out _animator, "No animator detected");
    }

    void OnEnable()
    {
        _controls.Actions.Enable();
    }

    void Update()
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

        if(isRunning)   transform.Translate(_runSpeed * Time.deltaTime * inputAs3D);
        else            transform.Translate(_walkSpeed * Time.deltaTime * inputAs3D);
    }
}
