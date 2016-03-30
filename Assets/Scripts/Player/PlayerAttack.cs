using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    //components
    [SerializeField]
    private Rigidbody2D _rb;
    private Renderer _renderer;
    //components

    //scripts
    [SerializeField]
    private PlayerFlip _playerFacingRight;
    private PlayerTransformation _WolfMode;
    private IHealth _hunterHealth;
    //scripts

    //ints
    private int _layermask;
    //ints

    //bools
    private bool _aniIsDone = false;
    public bool atackIsDone = true;
    public bool dealingDamage = false;
    //bools
    //floats 
    [SerializeField]
    private float _damageToDeal;
    private float _wolfDamage = 8f;
    private float _humanDamage = 10f;
    //floats

    //gameobjects
    [SerializeField]
    private Transform _atackPostionHuman;
    [SerializeField]
    private Transform _atackPostionWolf;
    //gameobjects   

   
    //delegates
    public delegate void EnemyDamageEventhandler(float damageDeal);
    public EnemyDamageEventhandler damageEnemy;
    //delegates

    void Start()
    {
        AsignVariables();

    }

    private void AsignVariables()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerFacingRight = GetComponent<PlayerFlip>();
        _renderer = GetComponent<Renderer>();
        _layermask = LayerMask.GetMask(GameTags.enemy);
        _WolfMode = GetComponent<PlayerTransformation>();
        _atackPostionHuman = transform.FindChild("AtackPositionHuman");
        _atackPostionWolf = transform.FindChild("AtackPositionWolf");
        CalculateAtackDamage();
    }

  
    void Update()
    {

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


    void Strike()
    {
        //this code is just for testing purposes and can be deleted when the player atack is finilazed
        if (_WolfMode.wolfMode == false)
        {
            Debug.DrawRay(_atackPostionHuman.position, new Vector2(2 * GetPlayerDirection(), 0));


        }
        else
        {
            float Wolfdamage = (_damageToDeal / 100) * 80;
            Debug.DrawRay(_atackPostionWolf.position, new Vector2(2 * GetPlayerDirection(), 0));

        }
        //test code ends here

       StartCoroutine(Atack());

    }
    //to determine the atack damage
    private float CalculateAtackDamage() {
        if (_WolfMode.wolfMode == true)
        {
            return _wolfDamage;
        }
     if (_WolfMode.wolfMode == false)
        {
            return _humanDamage;
        }
        else
        {
            Debug.Log("no mode found, ERROR");
            return 0f;
        }
    }
    //needs refactoring
    IEnumerator Atack()
    {
        atackIsDone = false;
        HitCheck();


        yield return new WaitForEndOfFrame();
    }
    //see if the player hit the enemy
    private void HitCheck()
    {

        RaycastHit2D enemyInRange = Physics2D.Raycast(this.transform.position, new Vector2((2 * GetPlayerDirection()), 0), 2, _layermask);
        if (enemyInRange.collider != null)
        {
            _hunterHealth = enemyInRange.transform.gameObject.GetComponent<IHealth>();
            StartCoroutine(Onhit(enemyInRange.collider.gameObject));
        }
        else
        {
            Debug.Log("no hittable objects");
        }
    }
    //code to run when the enemy is damaged
    private IEnumerator Onhit(GameObject other)
    {

        //add and eventually delete delegate here
        damageEnemy += _hunterHealth.ChangeHealth;
        damageEnemy(_damageToDeal);
        damageEnemy -= _hunterHealth.ChangeHealth;
        yield return new WaitForEndOfFrame();
        //atackIsDone = true; 

    }

    


    

}