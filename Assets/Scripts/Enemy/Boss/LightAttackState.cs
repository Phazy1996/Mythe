using UnityEngine;
using System.Collections;

public class LightAttackState : State {

    private Vector2 _WalkLeft = new Vector2(-3,0);
    private Vector2 _WalkRight = new Vector2(3,0);

    private Vector2 _StartPoint;
    private Vector2 _DestPoint;

    private bool _OnLeftSide;

    private GameObject _Camera;

    private SpriteRenderer _BossRenderer;

    public override void Enter()
    {
        Debug.Log("LightAttack");
        _BossRenderer = GetComponent<SpriteRenderer>();
        _Camera = GameObject.FindWithTag("MainCamera");
        CheckSide();
    }

    public override void Act()
    {
        if (_OnLeftSide == true){
            Debug.Log("attack to right");
            WalkForwardR();
        }  
        else{
            Debug.Log("attack to left");
            WalkForwardL();
        }     
    }

    public override void Reason()
    {

    }

    void CheckSide()
    {
        if (transform.position.x > _Camera.transform.position.x)
            _OnLeftSide = false;
        else
            _OnLeftSide = true;
    }

    void WalkForwardL()
    {
        //make boss step to the left and then call attack
        if(transform.position.x >= (_StartPoint.x +2f))
        {
            transform.Translate(_WalkLeft * Time.deltaTime);
            _BossRenderer.color = Color.red;
            Debug.Log("step to centre");
        }
        else
        {
            Attack();
            Debug.Log("ATTACK");
        }
    }

    void WalkForwardR()
    {
        //make boss step to the right and then call attack
        if (transform.position.x <= (_StartPoint.x - 2f))
        {
            transform.Translate(_WalkRight * Time.deltaTime);
            _BossRenderer.color = Color.red;
            Debug.Log("step to centre");
        }
        else
        {
            Attack();
            Debug.Log("ATTACK");
        }
    }

    void WalkBackR()
    {
        //make boss walk back to where it started then switch state
        if(transform.position.x >= (_StartPoint.x))
        {
            
        }
    }

    void WalkBackL()
    {
        //make boss walk back to where it started then switch state
    }

    void Attack()
    {
        //make boss attack and then call walkback
        _BossRenderer.color = Color.black;
        //play attack animation, when thats over, call walkback
    }
}
