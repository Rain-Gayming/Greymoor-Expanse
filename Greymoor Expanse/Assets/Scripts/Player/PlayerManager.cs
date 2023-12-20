using System.Collections;
using System.Collections.Generic;
using RainGayming.Player.Inputs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Player
{
    public class PlayerManager : MonoBehaviour
    {
        [BoxGroup("References")]
        public InputHandler inputHandler;
        [BoxGroup("References")]
        public Animator anim;

        public void Update()
        {
            inputHandler.isInteracting = anim.GetBool("isInteracting");
            inputHandler.rollFlag = false;
        }
    }
}