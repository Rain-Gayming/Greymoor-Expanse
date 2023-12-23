using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityAnimation;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace RainGayming.UI.Player
{
    public class PlayerUI : MonoBehaviour
    {
        [BoxGroup("Bars")]
        public Slider healthBar;
        [BoxGroup("Bars")]
        public Slider manaBar;
        [BoxGroup("Bars")]
        public Slider staminaBar;
        [BoxGroup("Bars")]
        public Slider expBar;

        public void UpdateBar(float value, EPlayerBar bar, bool max)
        {
            switch (bar)
            {
                case EPlayerBar.health:
                    if(!max)
                        healthBar.value = value;
                    else                        
                        healthBar.maxValue = value;
                break;
                case EPlayerBar.mana:
                    if(!max)
                        manaBar.value = value;
                    else                        
                        manaBar.maxValue = value;
                break;
                case EPlayerBar.stamina:
                    if(!max)
                        staminaBar.value = value;
                    else                        
                        staminaBar.maxValue = value;
                break;
                case EPlayerBar.exp:
                    if(!max)
                        expBar.value = value;
                    else                        
                        expBar.maxValue = value;
                break;
            }
        }
    }
}