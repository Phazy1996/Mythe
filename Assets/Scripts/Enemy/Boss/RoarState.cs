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
    private bool _OnLeftSide;

    private Vector2 _OriginScale;

    private BossShooter _BossShootL;
    private BossShooter _BossShootR;

    private Animator _Anim;

    private GameObject _Camera;

    void Start()
    {
        _OriginScale = transform.localScale;
    }

    public override void Enter()
    {
        _Camera = GameObject.FindWithTag("MainCamera");
        
        _CurrentRoarTime = 0f;
        //Debug.Log("Roar State Enter");

        _BossShootL = GameObject.FindWithTag("BossLShooter").GetComponent<BossShooter>();
        _BossShootR = GameObject.FindWithTag("BossRShooter").GetComponent<BossShooter>();

        _Anim = GetComponent<Animator>();
        _Anim.SetInteger("State", 0);
        //call castshockwave function on each side of the boss
        _BossShootL.CastShockwave();
        _BossShootR.CastShockwave();

        
        FlipSprite();
    }

    public override void Act()
    {
        CheckSide();
        Debug.Log(_OnLeftSide);
        _CurrentRoarTime += Time.deltaTime;
        //_BossRenderer.color = Color.blue;
    }

    public override void Reason()
    {
        
        if (_CurrentRoarTime > _RoarDuration)
        {
            //reset roar time
            _CurrentRoarTime = 0;
        }  
    }

    void CheckSide()
    {
        Debug.Log("CheckSide is gaande");
        if (transform.position.x > _Camera.transform.position.x){
            _OnLeftSide = false; Debug.Log("OnLeft is " + _OnLeftSide);
        }
        else{
            _OnLeftSide = true; Debug.Log("OnLeft is " + _OnLeftSide);
        }
            
    }

    void SwitchStateRoar()
    {
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

    void FlipSprite()
    {
        if (_OnLeftSide == true)
        {
            //you gotta face right, boss originally faced left
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        else
        {
            //you gotta face left, boss originally faced left
            transform.localScale = _OriginScale;
        }
    }
}
