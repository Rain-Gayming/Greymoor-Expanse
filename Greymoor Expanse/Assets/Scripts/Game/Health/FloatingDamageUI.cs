using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;


namespace RainGayming.Game.Stats.UI
{
    public class FloatingDamageUI : MonoBehaviour
    {
        [BoxGroup("UI")]
        public TMP_Text damageText;
        [BoxGroup("UI")]
        public float change;
        [BoxGroup("UI")]
        public float timeTillDestroy;
        
        [BoxGroup("Health")]
        public float health;

        public void Start()
        {
            damageText.text = health.ToString();
        }

        public void FixedUpdate()
        {
            transform.LookAt(Camera.main.transform);    

            Vector3 pos = transform.position;
            pos.y += change;
            
            transform.position = pos;

            timeTillDestroy -= Time.deltaTime;
            if(timeTillDestroy <= 0){
                Destroy(gameObject);
            }
        }
    }
}