using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
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

        [BoxGroup("Camera")]
        public Vector2 mouseMove;

        public void Awake()
        {
            inputActions = new PlayerControls();
            inputActions.Enable();
        }

        public void Update()
        {
            playerMovement = inputActions.Movement.Move.ReadValue<Vector2>();
            moveAmount = Mathf.Clamp01(Mathf.Abs(playerMovement.x) + Mathf.Abs(playerMovement.y));
            
            mouseMove = inputActions.Movement.Camera.ReadValue<Vector2>();
        }

        public void OnDisable() 
        {
            inputActions.Disable();
        }
    }
}
