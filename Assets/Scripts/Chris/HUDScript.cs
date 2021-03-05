using System;
using UnityEngine;
using UnityEngine.UI;

namespace Chris{
    public class HUDScript : GenericSingleton<HUDScript>
    {
        
        [SerializeField] private Text timerText;
        [SerializeField] private Text collectText;
        [SerializeField] private Text healthText;
        private int timerMinutes;
        private int timerSeconds;
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
        
        public override void Awake()
        {
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
            timerText.text = $"{timerMinutes}:{timerSeconds}";
        }
    }
}
