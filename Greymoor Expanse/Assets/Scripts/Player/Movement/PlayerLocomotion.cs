using RainGayming.Player.Inputs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Player.Movement
{
    public class PlayerLocomotion : MonoBehaviour
    {
        [BoxGroup("References")]
        public InputHandler inputHandler;
        [BoxGroup("References")]
        public PlayerAnimationHandler animationHandler;
        [BoxGroup("References")]
        public Transform cameraObject;
        [BoxGroup("References")]
        public Transform myTransform;
        [BoxGroup("References")]
        public Rigidbody rb;
        [BoxGroup("References")]
        public GameObject normalCamera;

        [BoxGroup("Movement Info")]
        [BoxGroup("Movement Info/Movement")]
        public float currentMovementSpeed;
        [BoxGroup("Movement Info/Movement")]
        public float walkSpeed;
        [BoxGroup("Movement Info/Movement")]
        public float crouchSpeed;
        [BoxGroup("Movement Info/Movement")]
        public float sprintSpeed;
        [BoxGroup("Movement Info")]
        public float rollDistance;
        [BoxGroup("Movement Info")]
        public float rotationSpeed;

        Vector3 normalVector;
        Vector3 targetPosition;
        Vector3 moveDirection;

        public void Start()
        {
            currentMovementSpeed = walkSpeed;
        }

        public void Update()
        {
            HandleMovement(Time.deltaTime);
            HandleRollAndSprinting(Time.deltaTime);

            if(animationHandler.canRotate){
                HandleRotation(Time.deltaTime);
            }
        }

        public void HandleMovement(float delta)
        {            
            moveDirection = cameraObject.forward * inputHandler.playerMovement.y;
            moveDirection += cameraObject.right * inputHandler.playerMovement.x;
            moveDirection.Normalize();
            moveDirection.y = 0;

            float cms = currentMovementSpeed;
            moveDirection *= cms;

            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
            rb.velocity = projectedVelocity;

            animationHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0);
        }

        public void HandleRollAndSprinting(float delta)
        {
            if(animationHandler.anim.GetBool("isInteracting")){
                return;
            }

            if(inputHandler.rollFlag){
                moveDirection = cameraObject.forward * inputHandler.playerMovement.y;
                moveDirection += cameraObject.right * inputHandler.playerMovement.x;

                if(inputHandler.moveAmount > 0){
                    animationHandler.PlayTargetAnimation("Rolling", true);
                    moveDirection.y = 0;

                    rb.velocity = transform.forward * rollDistance;
                    
                    Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                    myTransform.rotation = rollRotation;
                }else{
                    //Currently no backstep anim
                    
                    //animationHandler.PlayTargetAnimation("Backstep", true);
                }
            }
        }


        public void HandleRotation(float delta)
        {
            Vector3 targetDir = Vector3.zero;
            
            targetDir = cameraObject.forward * inputHandler.playerMovement.y;
            targetDir += cameraObject.right * inputHandler.playerMovement.x;

            targetDir.Normalize();
            targetDir.y = 0;

            if(targetDir == Vector3.zero){
                targetDir = myTransform.forward;
            }

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rotationSpeed * delta);

            myTransform.rotation = targetRotation;
        }

        
    }
}