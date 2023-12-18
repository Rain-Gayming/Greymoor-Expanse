using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using XNode;

namespace RainGayming.Quests
{
    [System.Serializable]
    public class QuestStep
    {
        public string stepName;
        public bool isCombat;

        [HideIf("isCombat", true)]
        public int amount;
    }
}