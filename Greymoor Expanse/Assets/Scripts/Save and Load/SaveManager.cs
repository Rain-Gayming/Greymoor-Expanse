using System.Collections;
using System.Collections.Generic;
using RainGayming.Loading.Scene;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Saving
{
    public class SaveManager : MonoBehaviour
    {
        [BoxGroup("References")]
        public SceneLoadManager loadManager;

        public void LoadSave(string name)
        {
            //Do loading stuff

            loadManager.LoadScene("Game");
        }
    }
}