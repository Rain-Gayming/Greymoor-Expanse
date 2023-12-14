using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Greymoor.UI.MenuManagement
{
    public class MenuManager : MonoBehaviour
    {
        [BoxGroup("Menu Manager Info")]
        public List<MenuObject> menus;
        
        public void CloseAllMenus()
        {
            for (int i = 0; i < menus.Count; i++)
            {
                menus[i].Toggle(false);
            }
        }        
        

        public void OpenMenu(MenuObject menu)
        {
            for (int i = 0; i < menus.Count; i++)
            {
                menus[i].Toggle(false);
            }

            menu.Toggle(true);
        }        
        
        public void OpenMenu(string menu)
        {
            for (int i = 0; i < menus.Count; i++)
            {
                menus[i].Toggle(false);

                if(menus[i].menuName == menu){
                    menus[i].Toggle(true);
                }
            }
        }
    }   
}
