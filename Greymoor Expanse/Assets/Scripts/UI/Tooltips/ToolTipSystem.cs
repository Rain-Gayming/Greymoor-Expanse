using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.UI.Tooltips
{
    public class ToolTipSystem : MonoBehaviour
    {
        public static ToolTipSystem instance;

        [BoxGroup("References")]
        public ToolTip tooltip;
        [BoxGroup("References")]
        public GameObject workInProgressMarker;

        void Awake() {
            instance = this;
        }

        public void Show(string content, string header, bool isWorkInProgress)
        {
            tooltip.rectTransform.gameObject.SetActive(true);
            tooltip.SetText(content, header);
            workInProgressMarker.SetActive(isWorkInProgress);
        }
        public void Hide()
        {
            tooltip.rectTransform.gameObject.SetActive(false);
        }
    }
}
