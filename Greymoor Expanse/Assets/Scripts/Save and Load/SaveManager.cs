using System.Collections;
using System.Collections.Generic;
using Greymoor.Loading.Scene;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Greymoor.Saving
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