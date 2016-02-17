using UnityEngine;
using System.Collections;

public class PlayerTransformation : MonoBehaviour {

    //SpriteRenderer
    private SpriteRenderer _playerRenderer;
    //SpriteRenderer

    //Bools
    [SerializeField]
    private bool _isGrounded = false; // Is the player grounded, or not?
    public bool transitionMode = false;
    public bool wolfMode = false;

    public bool wolfToHumanTransition = false;
    public bool humanToWolfTransition = false;

    private bool _runOnce = false;
    //Bools


    //Collider2D
    private BoxCollider2D _thisBoxCollider2D;
    //Collider2D

    //Scripts
    private PlayerMovement _groundedBoolean; // Checks if the player is grounded or not.
    //Scripts


    void Start()
    {
        _playerRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        _groundedBoolean = this.gameObject.GetComponent<PlayerMovement>();

        _thisBoxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
    }

	void Update () 
    {
            TransformButton();

           /// AdjustBoxCollider2D();
	}

    private void TransformButton()
    {
        if (_groundedBoolean._isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {

                _runOnce = false;

                if (!wolfMode)
                {
                    StartCoroutine("WolfTransformation");
                }
                else
                    StartCoroutine("HumanTransformation");
            }
        }
       
    }

    IEnumerator WolfTransformation()
    {
        float _secondsToWait = 0.5f;

        humanToWolfTransition = true;
        transitionMode = true;

        yield return new WaitForSeconds(_secondsToWait);

        transitionMode = false;
        humanToWolfTransition = false;
        wolfMode = true;

        if (!_runOnce)
        {
            AdjustBoxCollider2D();
            _runOnce = true;
        }

        
    }

    IEnumerator HumanTransformation()
    {
        float _secondsToWait = 0.5f;

        wolfToHumanTransition = true;
        transitionMode = true;


        yield return new WaitForSeconds(_secondsToWait);

        transitionMode = false;
        wolfToHumanTransition = false;
        wolfMode = false;

        if (!_runOnce)
        {
            AdjustBoxCollider2D();
            _runOnce = true;
        }

    }

    private void AdjustBoxCollider2D()
    {
        if (wolfMode)
        {
            _thisBoxCollider2D.size = new Vector2(2.5f, 1.5f);
            _thisBoxCollider2D.offset = new Vector2(0, -0.4f);
        }
        else
        {
            _thisBoxCollider2D.size = new Vector2(1f, 2.4f);
            _thisBoxCollider2D.offset = new Vector2(0, 0);
        }
            
            
    }
}
