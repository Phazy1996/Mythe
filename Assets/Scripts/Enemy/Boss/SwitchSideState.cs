using UnityEngine;
using System.Collections;

public class SwitchSideState : State {

    private Rigidbody2D rb;

    private bool _OnLeftSide;
    private bool _PreviousSideLeft;

    private GameObject _Camera;

    [SerializeField] private float _ObstacleProximity;

    private int _ObstacleMask;

    private Vector2 _RunLeftVector = new Vector2(-12, 0);
    private Vector2 _RunRightVector = new Vector2(12, 0);

    public override void Enter()
    {
        rb = GetComponent<Rigidbody2D>();
        _Camera = GameObject.FindWithTag("MainCamera");
        _ObstacleMask = LayerMask.GetMask("Ground");

        //store the side on wich the boss started
        _PreviousSideLeft = _OnLeftSide;

        //check on what side of screen boss is
        CheckSide();
    }

    public override void Act()
    {
        //Debug.Log("it is ..." + _OnLeftSide + "... that boss is on left side");

        //run left or right depending on stage position
        if (_OnLeftSide)
            transform.Translate(_RunRightVector * Time.deltaTime);
        else
            transform.Translate(_RunLeftVector *  Time.deltaTime);

        //check when to stop running with raycast
        if(_OnLeftSide == true)
            ObstacleCheckRight();
        else if(_OnLeftSide == false)
            ObstacleCheckLeft();
    }

    public override void Reason()
    {
        //check if boss is on other side from where it started
        if (_PreviousSideLeft != _OnLeftSide)
            GetComponent<StateMachine>().SetState(StateID.Roar);
    }

    void ObstacleCheckRight()
    {
        //cast raycast to the right to check when boss hit the wall and needs to stop running
        RaycastHit2D _ObstacleCheck = Physics2D.Raycast(transform.position, Vector2.right, _ObstacleProximity, _ObstacleMask);
        if (_ObstacleCheck.collider.tag == GameTags.ground)
            _OnLeftSide = false;
    }

    void ObstacleCheckLeft()
    {
        //cast raycast to the left to check when boss hit the wall and needs to stop running
        RaycastHit2D _ObstacleCheck = Physics2D.Raycast(transform.position, Vector2.left, _ObstacleProximity, _ObstacleMask);
        if (_ObstacleCheck.collider.tag == GameTags.ground)
            _OnLeftSide = true;
    }

    void CheckSide()
    {
        //check what side boss is on by comparing position to camera position
        if(transform.position.x > _Camera.transform.position.x)
            _OnLeftSide = false;
        else
            _OnLeftSide = true;
    }
}
