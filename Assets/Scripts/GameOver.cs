using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    [SerializeField]
    private Score _score;

    [SerializeField]
    Text _scoreField;

    public void Over() {
        _scoreField.text = "Score: " + _score.score;
    }

}
