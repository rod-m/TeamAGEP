using UnityEngine;
using UnityEngine.UI;

public class GameManagerSingleton : GenericSingleton<GameManagerSingleton>
{
    private int _score = 0;

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            _score_ui.text = "Score " + Score;
        }
    }

    public int Lives { get; set; }
    private Text _score_ui;

    public override void Awake()
    {
        base.Awake();
        _score_ui = GameObject.Find("Score").GetComponent<Text>();
        if (_score_ui == null)
        {
            Debug.LogError("Create Canvas UI Text called Score!");
        }
    }
}