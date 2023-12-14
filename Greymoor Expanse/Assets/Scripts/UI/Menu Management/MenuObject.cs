using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Greymoor.UI.MenuManagement
{
    public class MenuObject : MonoBehaviour
    {
        [BoxGroup("Menu Info")]
        public GameObject menuObj;
        [BoxGroup("Menu Info")]
        public string menuName;
        [BoxGroup("Menu Info")]
        public bool isOpen;

        public void Toggle()
        {
            isOpen = !isOpen;
            
            menuObj.SetActive(isOpen);
        }

        public void Toggle(bool isTrue)
        {
            if(isTrue){
                isOpen = true;
            }else{
                isOpen = false;
            }
            
            menuObj.SetActive(isOpen);
        }
    }   
}

