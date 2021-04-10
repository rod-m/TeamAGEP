using System;
using UnityEngine;
using UnityEngine.UI;

namespace Chris{
    public class HUDScript : GenericSingleton<HUDScript>, IPickUpTime
    {
        
        [SerializeField, Header("UI Element showing time remaining")] private Text timerText;
        [SerializeField, Header("UI Element showing collectibles collected")] private Text collectText;
        [SerializeField, Header("UI Element showing player's health")] private Text healthText;
        [SerializeField, Header("How many minutes timer should count down from")] private int timerMinutes;
        [SerializeField, Header("How many seconds timer should count down from, not including minutes")] private float timerSeconds;
        private int _collected;

        public int Collected{
            get => _collected;
            set{
                //Debug.Log("Has been collected");
                _collected = value;
                collectText.text = $"Collected:{_collected}";
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
                Debug.LogError("Create Canvas UI Text called Health Text!");
            }
        }
        private void LateUpdate(){
            // I would use seconds to countdown, then simply convert seconds to minutes:seconds
            /*
             * to get minute just divide by 60
             * to get seconds use modulus, timerSeconds = totalSeconds % 60
             */
            if(timerMinutes > 0 || timerSeconds > 0){
                if(timerSeconds <= 0){
                    timerMinutes -= 1;
                    timerSeconds = 59;
                }
                timerSeconds -= 1 * Time.deltaTime;
                // Any reason why you have greater than 9 seconds here?
                if(timerSeconds > 9){timerText.text = $"{timerMinutes}:{Mathf.RoundToInt(timerSeconds)}";}
                else {timerText.text = $"{timerMinutes}:0{Mathf.RoundToInt(timerSeconds)}";}
            }
        }

        public void PickUpTime()
        {
            throw new NotImplementedException();
        }
    }
}
