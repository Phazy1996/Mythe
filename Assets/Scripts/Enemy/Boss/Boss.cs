using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This script includes the states the boss can access during his battle with the player
 */

public enum StateID
{
    NullStateID = 0,
    LightAttack = 1,
    HeavyAttack = 2,
    SwitchSide = 3,
    Roar = 4,
    Dead = 5
}

public class Boss : MonoBehaviour {

    private StateMachine stateMachine;

    private BossHealth _BossHealth;

	void Start () 
    {
        stateMachine = GetComponent<StateMachine>();
        MakeStates();
        stateMachine.SetState(StateID.Roar);

        _BossHealth = GetComponent<BossHealth>();

        _BossHealth._DepleteBossHealth += Die;
	}

    void Die()
    {
        Debug.Log("BOSS IS DEAD");
    }
	
	void MakeStates()
    {
        stateMachine.AddState(StateID.LightAttack, GetComponent<LightAttackState>());
        stateMachine.AddState(StateID.HeavyAttack, GetComponent<HeavyAttackState>());
        stateMachine.AddState(StateID.SwitchSide, GetComponent<SwitchSideState>());
        stateMachine.AddState(StateID.Roar, GetComponent<RoarState>());
        stateMachine.AddState(StateID.Dead, GetComponent<DeadState>());
    }
}
