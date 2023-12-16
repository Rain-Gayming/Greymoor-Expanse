using Greymoor.Player.Inputs;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace Greymoor.Player.Camera
{
    public class CameraHandler : MonoBehaviour
    {
        [BoxGroup("References")]
        public InputHandler inputHandler;
        [BoxGroup("References")]
        public Transform targetTransform;
        [BoxGroup("References")]
        public Transform cameraTransform;
        [BoxGroup("References")]
        public Transform cameraPivotTransform;
        [BoxGroup("References")]
        public Transform myTransform;

        [BoxGroup("Stuff")]
        public Vector3 cameraPosition;

        [BoxGroup("Collision")]
        public LayerMask ignoreLayers;
        
        [BoxGroup("Speeds")]
        public float lookSpeed = 0.1f;
        [BoxGroup("Speeds")]
        public float followSpeed = 0.1f;
        [BoxGroup("Speeds")]
        public float pivotSpeed = 0.03f;

        [BoxGroup("Pivot")]
        public float minimumPivot = -35;
        [BoxGroup("Pivot")]
        public float maximumPivot = 35;
        float defaultPosition;
        float lookAngle;
        float pivotAngle;

        public void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Update()
        {
            FollowTarget(Time.deltaTime);
            HandleCameraRotation(Time.deltaTime);
        }

        public void FollowTarget(float delta)
        {
            Vector3 targetPos = Vector3.Lerp(myTransform.position, targetTransform.position, delta / followSpeed);
            myTransform.position = targetPos;
        }

        public void HandleCameraRotation(float delta)
        {
            lookAngle += (inputHandler.mouseMove.x * lookSpeed) / delta;
            lookAngle /= (inputHandler.mouseMove.y * lookSpeed) / delta;

            lookAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle;
            Quaternion targetRotation = Quaternion.Euler(rotation);
            myTransform.rotation = targetRotation;

            rotation = Vector3.zero;
            rotation.x = pivotAngle;

            targetRotation = Quaternion.Euler(rotation);
            cameraPivotTransform.localRotation = targetRotation;
            
        }
    }
}
