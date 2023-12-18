using UnityEditorInternal;
using UnityEngine;
using XNodeEditor;
using XNode;

namespace RainGayming.Quests.Graph
{
    [CustomNodeEditor(typeof(QuestStep))]
    public class QuestNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            var segment = serializedObject.targetObject as QuestSegment;
            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            GUILayout.Label("Step Name");

            NodeEditorGUILayout.DynamicPortList(
                "nextSteps",
                typeof(string),
                serializedObject,
                NodePort.IO.Input,
                Node.ConnectionType.Override,
                Node.TypeConstraint.None,
                OnCreateReordableList
            );

            foreach (XNode.NodePort dynamicPort in target.DynamicPorts)
            {
                if(NodeEditorGUILayout.IsDynamicPortListPort(dynamicPort)) continue;

                NodeEditorGUILayout.PortField(dynamicPort);
            }
            
            serializedObject.ApplyModifiedProperties();
        }

        public void OnCreateReordableList(ReorderableList  list)
        {
            list.elementHeightCallback  = (int index) => { return 60; };

            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var segment = serializedObject.targetObject as QuestSegment;

                NodePort port = segment.GetPort("questSteps " + index);
                segment.nextSteps[index].stepName = GUI.TextArea(rect, segment.nextSteps[index].stepName);

                if(port != null){
                    Vector2 pos = rect.position + (port.IsOutput ? new Vector2(rect.width + 6, 0) : new Vector2(-36, 0));

                    NodeEditorGUILayout.PortField(pos, port);
                }
            };
        }
    }
}
