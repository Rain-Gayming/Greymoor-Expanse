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
        [BoxGroup("Movement Info/Rolling")]
        public float rollDistance;
        
        [BoxGroup("Movement Info/Airial")]
        public float gravity = -9.81f;
        [BoxGroup("Movement Info/Airial")]
        public bool isGrounded;
        [BoxGroup("Movement Info/Airial")]
        public float groundArea;
        [BoxGroup("Movement Info/Airial")]
        public Transform groundPoint;
        [BoxGroup("Movement Info/Airial")]
        public float jumpVelocity;
        [BoxGroup("Movement Info/Airial")]
        public LayerMask jumpableMask;
        [BoxGroup("Movement Info/Airial")]
        public float airDrag;
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
            isGrounded = Physics.CheckSphere(groundPoint.position, groundArea, jumpableMask);

            if(isGrounded){
                rb.drag = 0;
            }else{
                rb.drag = airDrag;
                
                Vector3 gravVelocity = new Vector3(rb.velocity.x, -gravity, rb.velocity.z);
                rb.velocity = gravVelocity;
            }
        
            HandleMovement(Time.deltaTime);
            HandleRollAndSprinting(Time.deltaTime);


            if(inputHandler.jump && isGrounded){
                inputHandler.jump = false;
                HandleJump(Time.deltaTime);
            }

            if(animationHandler.canRotate && !inputHandler.isInteracting){
                HandleRotation(Time.deltaTime);
            }
        }

        public void HandleMovement(float delta)
        {
            if(!inputHandler.isInteracting){
                moveDirection = cameraObject.forward * inputHandler.playerMovement.y;
                moveDirection += cameraObject.right * inputHandler.playerMovement.x;
            }
            moveDirection.Normalize();

            if(isGrounded){
                moveDirection.y = 0;
            }

            float cms = currentMovementSpeed;
            moveDirection *= cms;

            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
            rb.velocity = projectedVelocity;

            animationHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0);
        }

        public void HandleJump(float delta)
        {
            rb.AddForce(transform.up * jumpVelocity, ForceMode.Impulse);
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