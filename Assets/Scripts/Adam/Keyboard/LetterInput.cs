using UnityEngine;
using UnityEngine.UI;

namespace Adam.Keyboard
{
    public class LetterInput : MonoBehaviour
    {
        /*
         * Display the unicode characters within a button prefab.
         * Display the next and previous letters above the button prefab
         * Have the directional keys (up/down arrows) control the value of the unicode.
         */

        [SerializeField] private Text letter;

        [SerializeField] private Text precedingLetter;
        [SerializeField] private Text succeedingLetter;

        //private List<char> _chars = new List<char>();

        private int _index = 26;
        private int _charMaximum = 27;
        private int _charMinimum = -1;
        
        //private readonly char[] _chars = new char[26];

        /*
        private void OnEnable()
        {
            for (var i = 0; i < _chars.Length; i++)
            {
                const int c = 65;
                Debug.Log((char)(c+i));
            }
        }
        */

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _index++;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _index--;
            }

            var newIndex = _index % 26;
 
            //Debug.Log(_index);
            letter.text = $"{(char)(newIndex+65)}";

            succeedingLetter.text = $"{(char)(newIndex+66)}";
            precedingLetter.text = $"{(char)(newIndex+64)}";
        }
    }
}