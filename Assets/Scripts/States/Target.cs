using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateID
{
    NullStateID = 0,
    Patroll = 1,
    Follow = 2
}


public class Target : MonoBehaviour {

    

    public StateMachine StateMachine;

    // Use this for initialization
    void Start () {
        StateMachine = GetComponent<StateMachine>();

        StateMachine.AddState(StateID.Patroll, GetComponent<PatrollState>());
        StateMachine.AddState(StateID.Follow, GetComponent<FollowState>());
        StateMachine.SetState(StateID.Patroll);
	}
	
}
