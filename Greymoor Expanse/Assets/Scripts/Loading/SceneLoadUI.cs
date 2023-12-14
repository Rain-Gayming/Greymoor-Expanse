using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Greymoor.Loading.Scene
{
    public class SceneLoadUI : MonoBehaviour
    {
        [BoxGroup("UI Info")]
        public Slider loadSlider;
        [BoxGroup("UI Info")]
        public AsyncOperation operation;

        public void Update()
        {
            if(operation != null){
                if(!operation.isDone){
                    loadSlider.value = operation.progress;
                }else{
                    operation = null;
                }
            }
        }
        
    }
   
}