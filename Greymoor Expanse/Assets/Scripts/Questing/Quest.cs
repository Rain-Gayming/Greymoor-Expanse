using System;
using System.Collections;
using System.Collections.Generic;
using RainGayming.Quests.Graph;
using UnityEngine;

namespace RainGayming.Quests
{
    [Serializable]
    public class Quest
    {
        public QuestGraph questGraph;
        public int currentStep;
    }
}