using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Greymoor.Player.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public PlayerControls inputActions;

        [BoxGroup("Movement")]
        public Vector2 playerMovement;

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
            
            mouseMove = inputActions.Movement.Camera.ReadValue<Vector2>();
        }

        public void OnDisable() 
        {
            inputActions.Disable();
        }
    }
}
