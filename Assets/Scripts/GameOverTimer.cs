using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTimer : MonoBehaviour {

    [SerializeField] private float _time = 10;

    private Counter _timer;
    [SerializeField] private GameOver _gameOver;
    private Text _text;

	// Use this for initialization
	void Start () {

        _text = GetComponent<Text>();

        _timer = new Counter(_time, CounterMode.Down, 0.1f);
        _timer.refreshEvent.AddListener(CheckGameOver);
        _timer.Start();
	}

    public void ResetTimer()
    {
        _timer.Reset();
    }

    private void CheckGameOver()
    {
        float time = (Mathf.Round(_timer.CurrentTime * 10)) / 10;
        _text.text = time.ToString() ;
        if(_timer.CurrentTime <= 0)
        {
            _gameOver.Gameover();
            _text.text = "0.0";
        }
    }
}
