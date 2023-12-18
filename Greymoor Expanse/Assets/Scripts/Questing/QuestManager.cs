using System.Collections;
using System.Collections.Generic;
using RainGayming.Quests.Graph;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Quests
{
    public class QuestManager : MonoBehaviour
    {
        public Quest quest;
        public QuestSegment activeSegment;

        [Button]
        public void UpdateQuest(int step)
        {
            for (int i = 0; i < quest.questGraph.nodes.Count; i++)
            {
            }

            quest.currentStep++;
            print(quest.questGraph.nodes[quest.currentStep].GetPort("questSteps " + quest.currentStep).ValueType);
        }
    }
}