/*           INFINITY CODE          */
/*     https://infinity-code.com    */

using UnityEditor;
using UnityEngine;

namespace InfinityCode.UltimateEditorEnhancer.SceneTools
{
    [InitializeOnLoad]
    public static class HighJumpToPoint
    {
        private static double lastShiftPressed;

#if UNITY_EDITOR_OSX
        private const EventModifiers MODIFIERS = EventModifiers.Command | EventModifiers.Shift;
#else
        private const EventModifiers MODIFIERS = EventModifiers.Control | EventModifiers.Shift;
#endif

        static HighJumpToPoint()
        {
            SceneViewManager.AddListener(OnSceneGUI);
        }

        private static void OnSceneGUI(SceneView view)
        {

        }
    }
}