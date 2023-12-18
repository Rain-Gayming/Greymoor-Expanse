using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RainGayming.UI.Tooltips
{
    public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string content;
        public string header;
        public bool isWorkInProgress;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            ToolTipSystem.instance.Show(content, header, isWorkInProgress);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ToolTipSystem.instance.Hide();
        }
    }
}