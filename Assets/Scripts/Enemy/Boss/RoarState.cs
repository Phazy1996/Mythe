using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoarState : State {

    [SerializeField]    private float _RoarDuration;
    private float _CurrentRoarTime;
    private int _RandomState;

    private SpriteRenderer _BossRenderer;

    public override void Enter()
    {
        _CurrentRoarTime = 0f;
        //Debug.Log("Roar State Enter");

        _BossRenderer = GetComponent<SpriteRenderer>();
        ObjectPool.instance.GetObjectForType("ShockwaveR", true);
        ObjectPool.instance.GetObjectForType("ShockwaveL", true);
    }

    public override void Act()
    {
        //Debug.Log("Roar");
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
