using System.Collections;
using System.Collections.Generic;
using RainGayming.Game.Stats.UI;
using RainGayming.UI.Player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Game.Stats
{
    class HealthManager : MonoBehaviour
    {
        [BoxGroup("References")]
        public StatManager statManager;

        [BoxGroup("Health")]
        public float currentHealth;

        [BoxGroup("Floating Damage")]
        public GameObject floatDamagePrefab;
        [BoxGroup("Floating Damage")]
        public float floatingDamageRange;

        [BoxGroup("Player Info")]
        public bool isPlayer;
        [BoxGroup("Player Info")]
        public PlayerUI playerUI;

        public void Start()
        {
            currentHealth = statManager.maxHealth;
            if(isPlayer){
                playerUI.UpdateBar(currentHealth, EPlayerBar.health, true);
                playerUI.UpdateBar(currentHealth, EPlayerBar.health, false);
            }
        }

        [BoxGroup("Debug")]
        [Button]
        public void ChangeHealth(float healthChange, bool isDamage)
        {
            if(isDamage){
                float dmg = healthChange -= statManager.defence;

                if(dmg <= 0){
                    dmg = healthChange / 3;
                }

                dmg = Mathf.Clamp(dmg, 0, 100000);
                dmg = Mathf.RoundToInt(dmg);
                currentHealth -= dmg;
                print(dmg);

                if(floatDamagePrefab){
                    GameObject newFloatingDamage = Instantiate(floatDamagePrefab);
                    
                    Vector3 trans = transform.localPosition;

                    float floatDamageX = Random.Range(trans.x - floatingDamageRange, trans.x + floatingDamageRange);
                    newFloatingDamage.transform.localPosition = new Vector3(floatDamageX, trans.y + 1.5f, trans.z);
                    newFloatingDamage.transform.LookAt(Camera.main.transform);
                    
                    newFloatingDamage.GetComponent<FloatingDamageUI>().health = dmg;
                }
            }else{
                currentHealth += healthChange;
            }

            currentHealth = Mathf.RoundToInt(currentHealth);

            if(isPlayer){
                playerUI.UpdateBar(currentHealth, EPlayerBar.health, false);
            }

            currentHealth = Mathf.Clamp(currentHealth, 0, statManager.maxHealth);
        }
    }
}