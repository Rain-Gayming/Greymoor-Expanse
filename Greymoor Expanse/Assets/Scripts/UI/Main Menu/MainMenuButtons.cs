using System.Collections;
using System.Collections.Generic;
using System.IO;
using Greymoor.Saving.World;
using Greymoor.World.Generation;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;


namespace Greymoor.UI.MainMenu
{
    public class MainMenuButtons : MonoBehaviour
    {
        [BoxGroup("World Generation")]
        public EWorldType worldType;
        [BoxGroup("World Generation")]
        public TMP_Text worldTypeText;
        [BoxGroup("World Generation")]
        public TMP_InputField worldNameInput;

        void Start() 
        {
            string wt = worldType.ToString();            
            string tmp = wt[0].ToString();
            tmp = tmp.ToUpper();
            wt = wt.Remove(0, 1);
            wt = wt.Insert(0, tmp);

            worldTypeText.text = wt;
        }

        public void SwapWorldType()
        {
            if(worldType == EWorldType.greymoor){
                worldType = EWorldType.sandbox;
            }else{
                worldType = EWorldType.greymoor;
            }

            string wt = worldType.ToString();            
            string tmp = wt[0].ToString();
            tmp = tmp.ToUpper();
            wt = wt.Remove(0, 1);
            wt = wt.Insert(0, tmp);

            worldTypeText.text = wt;
        }

        public void CreateWorld()
        {

            Directory.CreateDirectory(Application.persistentDataPath + "/" + worldNameInput.text);
            string worldSavePath = Application.persistentDataPath + "/" + worldNameInput.text + "/World.json";
            
            if(File.Exists(worldSavePath)){
                worldSavePath = Application.persistentDataPath + "/" + worldNameInput.text + "/World.json" + Random.Range(-100, 100) + ".json";
            }

            WorldSave newWorldSave = new WorldSave();
            newWorldSave.worldType = worldType;
            newWorldSave.worldName = worldNameInput.text;
            newWorldSave.seed = (int)Random.Range(-Mathf.Infinity, Mathf.Infinity);
            
            string jsonString = JsonUtility.ToJson(newWorldSave, true);
            File.WriteAllText(worldSavePath, jsonString);
        }
    }
}
