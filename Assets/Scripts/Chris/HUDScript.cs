using UnityEngine;
using UnityEngine.UI;

namespace Chris{
    public class HUDScript : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        [SerializeField] private Text collectText;
        [SerializeField] private Text healthText;
        private int timerMinutes;
        private int timerSeconds;
        private int collected;
        private float health;

        void Start()
        {
        
        }
        
        void Update()
        { 
            timerText.text = $"{timerMinutes}:{timerSeconds}";
            collectText.text = $"Collected:{collected}";
            healthText.text = $"Health:{health}";
        }
    }
}
