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
    private PlayerTransformation _WolfMode;
    //scripts

    //ints
    private int _layermask;
    //ints

    //floats 
    private float _damageToDeal = -10f;
    //floats

    //gameobjects
    [SerializeField]
    private Transform _atackPostionHuman;
    [SerializeField]
    private Transform _atackPostionWolf;
    //gameobjects   

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerFacingRight = GetComponent<PlayerFlip>();
        _renderer = GetComponent<Renderer>();
        _layermask = LayerMask.GetMask(GameTags.enemy);
        _WolfMode = GetComponent<PlayerTransformation>();
        _atackPostionHuman = transform.FindChild("AtackPositionHuman");
        _atackPostionWolf = transform.FindChild("AtackPositionWolf");
    }

    void FixedUpdate() {
        //  Debug.DrawRay(this.transform.position,Vector2.right);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Strike();
        }
    }

    private int GetPlayerDirection()
    {
        if (_playerFacingRight.facingRight == true)
        {
            return 1;
        }
        else if (_playerFacingRight.facingRight == false)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
       

    void Strike() {
        if (_WolfMode.wolfMode == false)
        {
            Debug.DrawRay(_atackPostionHuman.position, new Vector2(2 * GetPlayerDirection(), 0));

            DealDamage(_atackPostionHuman.position,_damageToDeal);

        }
        else
        {
            float Wolfdamage = (_damageToDeal / 100) * 80; 
            Debug.DrawRay(_atackPostionWolf.position, new Vector2(2 * GetPlayerDirection(), 0));
            DealDamage(_atackPostionWolf.position,(_damageToDeal /100)* 80);
            
        }
       
        
    }

    void DealDamage(Vector2 atackpostion, float damageToDeal) {
        RaycastHit2D enemyInRange = Physics2D.Raycast(this.transform.position, new Vector2((2 * GetPlayerDirection()), 0), 2, _layermask);
        if (enemyInRange.collider != null)
        {
            //send message to gameobject with healthchange method, replace this with tag from Gametags.cs
            enemyInRange.transform.SendMessage("HealthChange", _damageToDeal, SendMessageOptions.RequireReceiver);
        }
    }
}
