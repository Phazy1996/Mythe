using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    //components
    [SerializeField]
    private Rigidbody2D _rb;
    private Renderer _renderer;
    //components

    //scripts
    [SerializeField]
    private PlayerFlip _playerFacingRight;
    //scripts

    //ints
    private int _layermask;
    //ints

    //floats 
    private float _damageToDeal = -10f;
    //floats

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerFacingRight = GetComponent<PlayerFlip>();
        _renderer = GetComponent<Renderer>();
        _layermask = LayerMask.GetMask(GameTags.enemy);
        
    }

    void FixedUpdate() {
        //  Debug.DrawRay(this.transform.position,Vector2.right);
        Debug.DrawRay(this.transform.position, new Vector2(2 * GetPlayerDirection(),0));

        if (Input.GetKeyDown(KeyCode.E))
        {
            Strike();
        }
    }

    private int GetPlayerDirection()
    {
        if (_playerFacingRight._facingRight == true)
        {
            return 1;
        }
        else if (_playerFacingRight._facingRight == false)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
       

    void Strike() {
       
            RaycastHit2D enemyInRange = Physics2D.Raycast(this.transform.position, new Vector2((2 * GetPlayerDirection()),0),2,_layermask);
            if (enemyInRange.collider != null)
            {
                //send message to gameobject with healthchange method, replace this with tag from Gametags.cs
                 enemyInRange.transform.SendMessage("HealthChange", _damageToDeal, SendMessageOptions.RequireReceiver);
            }
        
    }
}
