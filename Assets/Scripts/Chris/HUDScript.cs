using System;
using UnityEngine;
using UnityEngine.UI;

namespace Chris{
    public class HUDScript : GenericSingleton<HUDScript>
    {
        
        [SerializeField] private Text timerText;
        [SerializeField] private Text collectText;
        [SerializeField] private Text healthText;
        [SerializeField] private int timerMinutes;
        [SerializeField] private float timerSeconds;
        private int collected;

        public int Collected{
            get => collected;
            set{
                //Debug.Log("Has been collected");
                collected = value;
                collectText.text = $"Collected:{collected}";
            }
        }

        private float health;

        public float Health{
            get => health;
            set{
                health = value;
                healthText.text = $"Health:{health}";
            }
        }
        
        private void OnValidate(){
            timerSeconds = Mathf.Clamp(timerSeconds,0, 59);
        }
        
        public override void Awake(){
            base.Awake();
            //Checks that counter exists on UI
            collectText = GameObject.Find("Counter Text").GetComponent<Text>();
            if (collectText == null)
            {
                Debug.LogError("Create Canvas UI Text called Counter Text!");
            }
            //Checks that health monitor exists on UI
            healthText = GameObject.Find("Health Text").GetComponent<Text>();
            if (healthText == null)
            {
                Debug.LogError("Create Canvas UI Text called Counter Text!");
            }
        }
        private void LateUpdate(){
            if(timerMinutes > 0 || timerSeconds > 0){
                timerText.text = $"{timerMinutes}:{Mathf.RoundToInt(timerSeconds)}";
                timerSeconds -= 1 * Time.deltaTime;
                if(timerSeconds <= 0){
                    timerMinutes -= 1;
                    timerMinutes = 59;
                }
            }
        }
    }
}
