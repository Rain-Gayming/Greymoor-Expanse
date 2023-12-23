using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Tayx.Graphy.Advanced;
using Unity.VisualScripting;
using UnityEngine;

namespace RainGayming.Player.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public PlayerControls inputActions;

        [BoxGroup("Movement")]
        public Vector2 playerMovement;
        [BoxGroup("Movement")]
        public float moveAmount;
        [BoxGroup("Movement")]
        public bool jump;

        [BoxGroup("Actions")]
        public bool bInput;
        [BoxGroup("Actions")]
        public bool rollFlag;
        [BoxGroup("Actions")]
        public bool isInteracting;

        [BoxGroup("Camera")]
        public Vector2 mouseMove;

        public void Awake()
        {
            inputActions = new PlayerControls();
            inputActions.Enable();
        }

        public void Update()
        {
            if(!isInteracting){
                playerMovement = inputActions.Movement.Move.ReadValue<Vector2>();
                moveAmount = Mathf.Clamp01(Mathf.Abs(playerMovement.x) + Mathf.Abs(playerMovement.y));
            }else{
                playerMovement = Vector3.zero;
                moveAmount = 0;
            }
            
            mouseMove = inputActions.Movement.Camera.ReadValue<Vector2>();

            inputActions.Actions.Roll.performed += _ => bInput = true;
            inputActions.Actions.Roll.canceled += _ => bInput = false;
            
            inputActions.Movement.Jump.performed += _ => jump = true;
            inputActions.Movement.Jump.canceled += _ => jump = false;

            HandleRollingInput(Time.deltaTime);
        }

        public void HandleRollingInput(float delta)
        {
            if(bInput){
                rollFlag = true;
            }
        }

        public void OnDisable() 
        {
            inputActions.Disable();
        }
    }
}
