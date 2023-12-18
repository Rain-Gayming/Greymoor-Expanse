using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Player.Movement
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        [BoxGroup("References")]
        public Animator anim;

        [BoxGroup("Values")]
        public bool canRotate;

        public void UpdateAnimatorValues(float vert, float hor)
        {
            #region Vert
            float v = 0;

            if(vert > 0 && vert < 0.55f){
                v = 0.5f;
            }else if(vert > 0.55f){
                v = 1;
            }else if(vert < 0 && vert > -0.55f){
                v = -0.5f;
            }else{
                v = 0;
            }
            #endregion
            
            #region Hor
            float h = 0;

            if(vert > 0 && vert < 0.55f){
                h = 0.5f;
            }else if(vert > 0.55f){
                h = 1;
            }else if(vert < 0 && vert > -0.55f){
                h = -0.5f;
            }else{
                h = 0;
            }
            #endregion
        
            anim.SetFloat("Vertical", v, 0.1f, Time.deltaTime);
            anim.SetFloat("Horizontal", h, 0.1f, Time.deltaTime);
        }

        public void SetRotate(bool value)
        {
            canRotate = value;
        }
    }
}
