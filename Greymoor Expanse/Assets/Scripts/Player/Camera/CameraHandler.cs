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

        [BoxGroup("Zoom")]
        public Vector3 baseCamPos;
        [BoxGroup("Zoom")]
        public float zoomSpeed = 5;
        [BoxGroup("Zoom")]
        public float currentZoom;
        [BoxGroup("Zoom")]
        public float minZoom;
        [BoxGroup("Zoom")]
        public float maxZoom;

        [BoxGroup("Collision")]
        public Vector3 cameraTransformPosition;
        [BoxGroup("Collision")]
        public float cameraSphereRadius = 0.2f;
        [BoxGroup("Collision")]
        public float cameraCollisionOffSet = 0.2f;
        [BoxGroup("Collision")]
        public float minimumCollisionOffset = 0.2f;
        [BoxGroup("Collision")]
        public float targetPosition;
        
        float defaultPosition;
        float lookAngle;
        float pivotAngle;
        Vector3 cameraFollowVelocity;

        public void Start()
        {
            baseCamPos = cameraTransform.position;
            defaultPosition = cameraTransform.localPosition.z;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Update()
        {
            FollowTarget(Time.deltaTime);
            HandleCameraRotation(Time.deltaTime);
            
            if(Input.GetAxis("Mouse ScrollWheel") != 0){
                //HandleZooming(Time.deltaTime);
            }
        }

        public void FollowTarget(float delta)
        {
            Vector3 targetPos = Vector3.SmoothDamp(myTransform.position, targetTransform.position, 
                ref cameraFollowVelocity, delta / followSpeed);
            myTransform.position = targetPos;
            HandleCameraCollisions(delta);
        }

        public void HandleZooming(float delta)
        {
            currentZoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * delta;                 
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            cameraTransform.position = new Vector3(baseCamPos.x, baseCamPos.y, currentZoom);
        }

        public void HandleCameraRotation(float delta)
        {
            lookAngle += (inputHandler.mouseMove.x * lookSpeed) / delta;
            pivotAngle -= (inputHandler.mouseMove.y * pivotSpeed) / delta;

            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle;
            Quaternion targetRotation = Quaternion.Euler(rotation);
            myTransform.rotation = targetRotation;

            //rotation = Vector3.zero;
            rotation.x = pivotAngle;

            targetRotation = Quaternion.Euler(rotation);
            cameraPivotTransform.localRotation = targetRotation;
            
        }

        public void HandleCameraCollisions(float delta)
        {
            targetPosition = defaultPosition;
            RaycastHit hit;
            Vector3 direction = cameraTransform.position - cameraPivotTransform.position;
            direction.Normalize();

            if(Physics.SphereCast(cameraPivotTransform.position, cameraSphereRadius, direction, out hit, Mathf.Abs(targetPosition), ignoreLayers)){
                float dis = Vector3.Distance(cameraPivotTransform.position, hit.point);
                targetPosition = (dis - cameraCollisionOffSet);
            }

            if(Mathf.Abs(targetPosition) < minimumCollisionOffset){
                targetPosition = -minimumCollisionOffset;
            }
            
            cameraTransformPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, delta / 0.2f);
            cameraTransform.localPosition = cameraTransformPosition;
        }
    }
}
