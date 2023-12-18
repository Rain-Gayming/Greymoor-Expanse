using System.Collections;
using System.Collections.Generic;
using RainGayming.Loading.Scene;
using RainGayming.Saving;
using Greymoor.Saving.World;
using Greymoor.World.Generation;
using Sirenix.OdinInspector;
using Unity.Burst;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace RainGayming.UI.MainMenu
{
    public class LoadCharacterButton : MonoBehaviour
    {
        [BoxGroup("References")]
        public SceneLoadManager sceneLoadManager;
        [BoxGroup("References")]
        public SaveManager saveManager; 

        [BoxGroup("World Info")]
        public WorldSave worldSave;

        public void OnPressed()
        {
            if(worldSave.worldType == EWorldType.greymoor){
                sceneLoadManager.LoadScene("Greymoor");
            }else{
                sceneLoadManager.LoadScene("Sandbox");
            }
        }
    }
}
