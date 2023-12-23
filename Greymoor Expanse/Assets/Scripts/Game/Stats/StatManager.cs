using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Game.Stats
{
    public class StatManager : MonoBehaviour
    {
        [BoxGroup("Stats")]
        public float maxHealth;
        [BoxGroup("Stats")]
        public float defence;
    }
}