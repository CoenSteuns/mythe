﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowState : PerceptionState {

    [Header("Follow")]
    [SerializeField] private float _speed = 10;
    [SerializeField] private string _playerName = "Player";
    [SerializeField] private float _timeInFollowWithoutPlayer = 3;

    private NavMeshAgent _NavMeshAgent;
    private GameObject _player;
    private Counter _counter;
    private Attack _damage;

    void Start()
    {
        _counter = new Counter();
        _player = GameObject.Find(_playerName);
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        _damage = GetComponentInChildren<Attack>();
    }

    public override void EnterState()
    {
        base.EnterState();
        _NavMeshAgent.speed = _speed;
        _damage.ConstantAttackMultiple();
    }

    public override void InState()
    {
        _NavMeshAgent.SetDestination(_player.transform.position);
    }

    public override void LeaveState()
    {
        base.LeaveState();
        _damage.StopConstantAttack();
    }

    public override void CheckState()
    {

        if (!GetPerception())
        {
            _counter.Reset();
            return;
        }

        if (_counter.CurrentTime == 0)
            _counter.Start();

        if(_counter.CurrentTime > _timeInFollowWithoutPlayer)
        GetComponent<StateMachine>().SetState(StateID.Patroll);
    }

    private IEnumerator Damage()
    {
        yield return new WaitForSeconds(1.5f);
        _damage.enabled = true;
    }
}
