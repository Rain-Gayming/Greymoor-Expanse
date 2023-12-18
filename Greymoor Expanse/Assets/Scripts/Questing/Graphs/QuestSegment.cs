using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace RainGayming.Quests.Graph
{
    [Serializable]
    public struct connection{}

    public class QuestSegment : Node
    {
        public string segmentName;

        [Input]
        public connection input;

        [Output(dynamicPortList = true)]
        public List<QuestStep> nextSteps;

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
