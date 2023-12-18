using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Greymoor.Saving.World;
using Greymoor.World.Generation;
using HarmonyLib;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;


namespace RainGayming.UI.MainMenu
{
    public class MainMenuButtons : MonoBehaviour
    {    
        string[] paths;
        List<string> directories;

        [BoxGroup("Load Character")]
        public GameObject worldButtonPrefab;    
        [BoxGroup("Load Character")]
        public Transform worldButtonPoint;

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

            DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath);
            info.GetDirectories();
            

            for (int i = 0; i < directories.Count; i++)
            {
                GameObject newButton = Instantiate(worldButtonPrefab);
                newButton.transform.SetParent(worldButtonPoint);

                string path = Application.persistentDataPath + directories[i] + "World.json";
                print(path);

                string fileContents = File.ReadAllText(path);

                WorldSave result = JsonUtility.FromJson<WorldSave>(fileContents);


                newButton.GetComponent<LoadCharacterButton>().worldSave = result;
                newButton.transform.localScale = Vector3.one; 
            }
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
