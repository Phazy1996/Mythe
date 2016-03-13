using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This script is for the boss' roar state wich activates shockwaves on both sides of the boss.
 * this script calls to the script that handles the activation of these shockwaves and an animation.
 * after these actions it switches to a random state
 */

public class RoarState : State {

    [SerializeField]    private float _RoarDuration;
    private float _CurrentRoarTime;
    private int _RandomState;

    private BossShooter _BossShootL;
    private BossShooter _BossShootR;

    private SpriteRenderer _BossRenderer;

    public override void Enter()
    {
        _CurrentRoarTime = 0f;
        //Debug.Log("Roar State Enter");

        _BossShootL = GameObject.FindWithTag("BossLShooter").GetComponent<BossShooter>();
        _BossShootR = GameObject.FindWithTag("BossRShooter").GetComponent<BossShooter>();

        //call castshockwave function on each side of the boss
        _BossShootL.CastShockwave();
        _BossShootR.CastShockwave();

        _BossRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Act()
    {
        _CurrentRoarTime += Time.deltaTime;
        _BossRenderer.color = Color.blue;
    }

    public override void Reason()
    {
        if (_CurrentRoarTime > _RoarDuration)
        {
            //reset roar time
            _CurrentRoarTime = 0;

            //pick random number
            _RandomState = Random.Range(0, 2);

            //switch state depending on randomly picked number
            switch (_RandomState)
            {
                case 0:
                    GetComponent<StateMachine>().SetState(StateID.SwitchSide);
                    break;
                case 1:
                    GetComponent<StateMachine>().SetState(StateID.LightAttack);
                    break;
                case 2:
                    GetComponent<StateMachine>().SetState(StateID.HeavyAttack);
                    break;
            }
        }    
    }
}
