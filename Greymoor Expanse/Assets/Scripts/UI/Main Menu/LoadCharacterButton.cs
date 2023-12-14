using System.Collections;
using System.Collections.Generic;
using Greymoor.Saving;
using Sirenix.OdinInspector;
using Unity.Burst;
using UnityEngine;


namespace Greymoor.UI.MainMenu
{
    public class LoadCharacterButton : MonoBehaviour
    {
        [BoxGroup("References")]
        public SaveManager saveManager;

        [BoxGroup("Character Info")]
        public string characterName;

        public void OnPressed()
        {
            saveManager.LoadSave(characterName);
        }
    }
}
