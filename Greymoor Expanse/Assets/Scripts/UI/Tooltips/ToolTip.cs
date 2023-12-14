using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;

namespace Greymoor.UI.Tooltips
{
    public class ToolTip : MonoBehaviour
    {
        [BoxGroup("References")]
        public RectTransform rectTransform;
        
        [BoxGroup("UI")]
        public TMP_Text headerText;
        [BoxGroup("UI")]
        public TMP_Text contentText;
        [BoxGroup("UI")]
        public LayoutElement layoutElement;
        
        [BoxGroup("Debug")]
        public bool debugMode;
        
        [BoxGroup("Text")]
        public int characterWrapLimit;

        public void Start()
        {
            debugMode = false;
        }

        public virtual void SetText(string content, string header = "")
        {
            if(string.IsNullOrEmpty(header)){
                headerText.gameObject.SetActive(false);
            }else{
                headerText.gameObject.SetActive(true);
                headerText.text = header;
            }
            if(contentText)
                contentText.text = content;
            UpdateUI();
        }

        void UpdateUI()
        {
            int headerLength = headerText.text.Length;
            int contentLength = 0;
            
            if(contentText)
                contentLength = contentText.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;

        }

        void Update() {
            Vector2 pos = Input.mousePosition;

            float pivotX = pos.x / Screen.width;
            float pivotY = pos.y / Screen.height;

            //rectTransform.pivot = new Vector2(pivotX, pivotY);
            transform.position = pos;

            if(debugMode){
#if UNITY_EDITOR
                UpdateUI();
#endif
            }
        }
    }
}