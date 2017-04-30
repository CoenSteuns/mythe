using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMachine : MonoBehaviour {

    private Dictionary<StateID, State> states = new Dictionary<StateID, State>();


    private State currentState;


    public void AddState(StateID ID, State state)
    {
        states.Add(ID, state);
    }

    public void RemoveState(StateID ID)
    {
        states.Remove(ID);
    }

    public void SetState (StateID ID)
    {
        if (!states.ContainsKey(ID))
            return;

        if (currentState != null)
        {
            currentState.LeaveState();
        }
    
        currentState = states[ID];

        currentState.EnterState();
    }

    public void Update()
    {
        if(currentState == null)
        {
            return;
        }

        currentState.InState();
        currentState.CheckState();
    }
}
