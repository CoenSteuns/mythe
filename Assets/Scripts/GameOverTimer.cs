using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameOverTimer : MonoBehaviour {


    [SerializeField]
    private float startTime;
    [SerializeField] private float _time = 60;
    [SerializeField] private Text _text;
    [SerializeField]
    UnityEvent TimerZero;

    private Coroutine _coro;

    private bool _isCounting;

    private void Start()
    {
        _text = GetComponent<Text>();
        
    }

    public void StartTimer()
    {
        print("sta");
        _time = startTime;
        _isCounting = true;
        _coro = StartCoroutine(counter());
    }

    public void StopTimer()
    {
        StopCoroutine(_coro);
        _isCounting = false;
    }

    private void SetTextTime()
    {
        GetComponent<Text>().text = "Time left: " + _time;
    }

    public IEnumerator counter()
    {
        while (_isCounting)
        {
            _time -= 1;
            SetTextTime();
            yield return new WaitForSeconds(1);
            if(_time < 1)
            {
                _isCounting = false;
                TimerZero.Invoke();
            }
        }
    }

}
