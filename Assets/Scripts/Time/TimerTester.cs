using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerTester : MonoBehaviour
{
    public Counter cOne;
    public Counter cTwo;

    public TimeSpan t;

    // Use this for initialization
    void Start () {
        cOne = new Counter();
        cTwo = new Counter(10, CounterMode.Down);
        cTwo.SetMonobehavior(this);
        cOne.SetMonobehavior(this);
        cTwo.refreshEvent.AddListener(counterTwo);
        cOne.refreshEvent.AddListener(NewTimeSpan);
        cOne.Start();


    }

    void counterTwo()
    {
        print(cTwo.CurrentTime);
        if (cTwo.CurrentTime == 0)
        {
            cTwo.Stop();
            cOne.Start();
        }
    }

    void NewTimeSpan()
    {
        t = TimeSpan.FromSeconds(cOne.CurrentTime);
        print("counter One: " + t.ToString());
        if (cOne.CurrentTime > 10)
        {
            cOne.Stop();
            cTwo.Start();
        }
    }//*/

}
