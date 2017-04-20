using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using Object = UnityEngine.Object;


public enum CounterMode
{
    Up = 1,
    Down = -1
}

public class Counter
{
    #region Variables
    #region Properties
    private float _startTime;
    private float _currentTime;
    private float _refreshTime;

    private bool _isPaused;

    private CounterMode _mode;
    #endregion
    #region Unity
    private MonoBehaviour _monoBehaviour;
    private Coroutine _timerCoroutine;
    public UnityEvent refreshEvent;
    #endregion
    #endregion

    #region Getters&Setters
    public float StartTime
    {
        get { return _startTime; }
        set { _startTime = value; }
    }
    public float CurrentTime
    {
        get { return _currentTime; }
    }
    public float RefreshTime
    {
        get { return _refreshTime; }
        set { _refreshTime = value; }
    }

    public bool IsPaused
    {
        get { return _isPaused; }
        set { _isPaused = value; }
    }
    public CounterMode Mode
    {
        get { return _mode; }
        set { _mode = value; }
    }
    #endregion

    public Counter(float startTime = 0, CounterMode mode = CounterMode.Up, float refreshTime = 1, UnityEvent timedEvent = null)
    {
        refreshEvent = timedEvent ?? new UnityEvent();
        _startTime = startTime;
        _mode = mode;
        _refreshTime = refreshTime;
    }

    public void Start()
    {
        if (!CheckMonobehavior())
        {
            return;
        }
        _timerCoroutine = _monoBehaviour.StartCoroutine(TimerCoroutine());
    }

    public void Stop()
    {
        if (!CheckMonobehavior())
        {
            return;
        }
        _monoBehaviour.StopCoroutine(_timerCoroutine);
        _currentTime = _startTime;
    }

    public void Reset()
    {
        _currentTime = _startTime;
    }

    public void SetMonobehavior(MonoBehaviour mono)
    {
        _monoBehaviour = mono;
    }

    private IEnumerator TimerCoroutine()
    {
        _currentTime = _startTime;
        while (true)
        {
            while (!_isPaused)
            {
                _currentTime += _refreshTime * (int)_mode;
                refreshEvent.Invoke();
                yield return new WaitForSeconds(_refreshTime);
            }
            yield return null;
        }
    }

    private bool CheckMonobehavior()
    {
        if (_monoBehaviour != null) { return  true;}
      
        _monoBehaviour = Object.FindObjectOfType<MonoBehaviour>();
        if (_monoBehaviour == null)
        {
            Debug.Log("No monobehavior in scene!");
            return false;
        }
        
        return true;
    }

}