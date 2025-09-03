using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Reuseables
{
    public class PlayerController : MonoBehaviour
    {
        #region Input
        [Header("Camera Input")]
        [SerializeReference] private InputActionReference _yLook;
        [SerializeReference] private InputActionReference _xLook;
        [SerializeReference] private InputActionReference _zLook;
        [Header("Movement Input")]
        [SerializeReference] private InputActionReference _zMovement;
        [SerializeReference] private InputActionReference _xMovement;
        [SerializeReference] private InputActionReference _jump;
        [SerializeReference] private InputActionReference _crouch;

        [Header("Action Input")]
        [SerializeField] private List<InputSpecialActionMap> _specialActions = new();

        [Serializable] public class InputSpecialActionMap { [SerializeReference] public InputActionReference Input; [SerializeReference] public PlayerSpecialAction Action; [HideInInspector] public bool Triggered; }
        public enum EPlayerAction {
            None, AllSpecial, Camera, Move, Jump, Crouch
        };
        #endregion

        void Update()
        {
            CheckInputs();
            ProcessLook(_xLookAmt, _yLookAmt, _zLookAmt);
        }
        void FixedUpdate()
        {
            ProcessMovement(_xMove, _zMove);
            ProcessJump(_jumpTriggered);
            ProcessCrouch(_crouchTriggered);
        }

        #region Action Processing
        [Header("Processing Settings")]
        float _xMove, _zMove, _xLookAmt, _yLookAmt, _zLookAmt;
        bool _jumpTriggered, _crouchTriggered;
        bool _isCrouching;

        private void CheckInputs()
        {
            if (_xMovement != null) _xMove = _xMovement.action.ReadValue<float>();
            if (_zMovement != null) _xMove = _zMovement.action.ReadValue<float>();
            if (_xLook != null) _xLookAmt = _xLook.action.ReadValue<float>();
            if (_yLook != null) _yLookAmt = _yLook.action.ReadValue<float>();
            if (_zLook != null) _zLookAmt = _zLook.action.ReadValue<float>();
            if (_jump != null) _jumpTriggered = _jump.action.IsPressed();
            if (_crouch != null) _crouchTriggered = _crouch.action.IsPressed();

            foreach (var action in _specialActions)
            { if(action.Input != null) action.Triggered = action.Input.action.IsPressed(); }
        }
        private void ProcessMovement(float xMove, float zMove)
        {
            Utils.Log(this, $"Moving: X: {xMove}, Z: {zMove}");
        }
        private void ProcessJump(bool triggered)
        {
            _jumpTriggered = false;
            Utils.Log(this, "Jumped!");
        }
        private void ProcessCrouch(bool triggered)
        {
            _crouchTriggered = false;
            _isCrouching = !_isCrouching;
            Utils.Log(this, _isCrouching ? "Crouuching!" : "Not Crouching!");
            
        }
        private void ProcessLook(float xLook, float yLook, float zLook)
        {
            Utils.Log(this, $"Looking: X: {xLook}, Y: {yLook}, Z: {zLook}");
        }

        #endregion

        #region Setup and Cleanup
        private void OnEnable()
        {
            SetControllable(true);
        }
        private void OnDisable()
        {
            SetControllable(false);
        }
        #endregion

        #region Setting Controls 
        public void SetControllable(bool controllable)
        {
            SetControllable(EPlayerAction.Camera, controllable);
            SetControllable(EPlayerAction.Move, controllable);
            SetControllable(EPlayerAction.Jump, controllable);
            SetControllable(EPlayerAction.Crouch, controllable);
            SetControllable(EPlayerAction.AllSpecial, controllable);
        }
        public void SetControllable(EPlayerAction action, bool controllable)
        {
            if (action == EPlayerAction.None) return;

            List<InputActionReference> actions = action switch
            {
                EPlayerAction.Camera => new() { _yLook, _xLook, _zLook },
                EPlayerAction.Move => new() { _zMovement, _xMovement },
                EPlayerAction.Jump => new() { _jump },
                EPlayerAction.Crouch => new() { _crouch },
                _ => new(),
            };
            foreach (InputSpecialActionMap a in _specialActions)
            { if (action == EPlayerAction.AllSpecial || a.Action.ActionType == action) actions.Add(a.Input); }

            foreach (InputActionReference a in actions)
            {
                if (a == null) continue;
                if (controllable) a.action.Enable(); else a.action.Disable();
            }
        }
        #endregion
    }
}
