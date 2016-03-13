using UnityEngine;
using System.Collections;

public class LightAttackState : State {

    private Vector2 _WalkLeft = new Vector2(-3,0);
    private Vector2 _WalkRight = new Vector2(3,0);

    private Vector2 _StartPoint;
    private Vector2 _DestPoint;

    private bool _OnLeftSide;
    private bool _DoneAttacking = false;

    private GameObject _Camera;

    private SpriteRenderer _BossRenderer;

    public override void Enter()
    {
        _BossRenderer = GetComponent<SpriteRenderer>();
        _Camera = GameObject.FindWithTag("MainCamera");
        CheckSide();

        //set startpoint where the boss was positioned when he entered this state
        _StartPoint.x = transform.position.x;
        //set destination point where the boss needs to walk for his light attack
        if (_OnLeftSide)
            _DestPoint.x = _StartPoint.x + 3;
        else
            _DestPoint.x = _StartPoint.x - 3;

        //Debug.Log("Destination: " + _DestPoint + ". StartPoint: " + _StartPoint);

        //Debug.Log("Reset Start & Dest Point");
        _BossRenderer.color = Color.green;
    }

    public override void Act()
    {
        //check if boss is done with light attack
        if (_DoneAttacking == false)
            WalkToCenter();
        else if (_DoneAttacking == true)
            WalkBack();
    }

    public override void Reason()
    {

    }

    void WalkToCenter()
    {
        //make boss walk to the destination point
        if(_OnLeftSide == true && transform.position.x < _DestPoint.x)
        {
            transform.Translate(_WalkRight * Time.deltaTime);
            //Debug.Log("walk right to centre");
        }else if(_OnLeftSide == false && transform.position.x > _DestPoint.x)
        {
            transform.Translate(_WalkLeft * Time.deltaTime);
            //Debug.Log("walk left to centre");
        }

        if (transform.position.x >= _DestPoint.x && _OnLeftSide == true)
        {
            Attack();
        }
        else if (transform.position.x <= _DestPoint.x && _OnLeftSide == false)
            Attack();
    }

    void WalkBack()
    {
        //Debug.Log("Now Walking Back");
        //make boss move back to the start point
        if(transform.position.x >= _StartPoint.x)
        {
            transform.Translate(_WalkLeft * Time.deltaTime);
            //check if boss is back where he started
            if (transform.position.x < _StartPoint.x)
            {
                SwitchRandomState();
                //Debug.Log("Boss is back where he started");
            }
        }else if(transform.position.x <= _StartPoint.x)
        {
            transform.Translate(_WalkRight * Time.deltaTime);
            //check if boss is back where he started
            if (transform.position.x > _StartPoint.x)
            {
                SwitchRandomState();
                //Debug.Log("Boss is back where he started");
            }
        }
    }

    void SwitchRandomState()
    {
        //reset attack
        _DoneAttacking = false;
        
        //pick random number for state selection
        int _RandomState;
        _RandomState = Random.Range(0, 2);
        switch (_RandomState)
        {
            case 0:
                GetComponent<StateMachine>().SetState(StateID.SwitchSide);
                break;
            case 1:
                GetComponent<StateMachine>().SetState(StateID.Roar);
                break;
            case 2:
                GetComponent<StateMachine>().SetState(StateID.HeavyAttack);
                break;
        }
    }

    void CheckSide()
    {
        if (transform.position.x > _Camera.transform.position.x)
            _OnLeftSide = false;
        else
            _OnLeftSide = true;
    }

    void Attack()
    {
        //make boss attack and then call walkback
        _BossRenderer.color = Color.black;
        _DoneAttacking = true;
        //play attack animation, when thats over, call walkback
    } 
}
