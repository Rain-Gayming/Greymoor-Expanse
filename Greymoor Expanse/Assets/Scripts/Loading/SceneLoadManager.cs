using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Greymoor.Loading.Scene
{
    public class SceneLoadManager : MonoBehaviour
    {
        [BoxGroup("Referenes")]
        public SceneLoadUI loadUI;

        public void LoadScene(string scene)
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(scene);
            loadUI.operation = op;
        }
    }
   
}