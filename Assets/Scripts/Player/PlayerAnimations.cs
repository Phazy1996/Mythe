using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour
{


    //Scripts
    private PlayerTransformation _playerTransformation;
    private PlayerMovement _playerMovement;
    //Scripts

    //Animator
    Animator anim;
    //Animator

    //Bools
    private bool _runOnce = false;
    private bool _runIdleOnce = false;
    public bool AtackingAni = false;
    //Bools


    void Start()
    {
        _playerTransformation = this.gameObject.GetComponent<PlayerTransformation>();
        _playerMovement = this.gameObject.GetComponent<PlayerMovement>();


        anim = this.gameObject.GetComponent<Animator>();
    }


    void Update()
    {

        HumanWalkAnimation();
        WolfWalkAnimation();

        JumpAnimations();

        TransformationAnimations();
        TransitionAnimations();
        WolfAtackAnimations();
    }

    private void HumanWalkAnimation()
    {
        if (!_playerTransformation.wolfMode)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                anim.SetBool("HumanIdle", false);
                anim.SetBool("HumanWalk", true);
            }
            else if (Input.GetAxis("Horizontal") == 0)
            {
                anim.SetBool("HumanIdle", true);
                anim.SetBool("HumanWalk", false);
            }
        }
    }


    private void WolfWalkAnimation()
    {
        if (_playerTransformation.wolfMode)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                anim.SetBool("WolfIdle", false);
                anim.SetBool("WolfWalk", true);
            }
            else if (Input.GetAxis("Horizontal") == 0)
            {
                if (!_runIdleOnce)
                {
                    anim.SetBool("WolfIdle", true);
                    _runIdleOnce = true;
                }

                _runIdleOnce = false;

                anim.SetBool("WolfWalk", false);
            }
        }
    }

    private void JumpAnimations()
    {
        if (_playerTransformation.wolfMode)
        {
            if (!_playerMovement._isGrounded && Input.GetAxis("Horizontal") == 0)
            {
                anim.SetBool("WolfIdle", false);
                anim.SetBool("WolfJump", true);

            }
            else if (!_playerMovement._isGrounded && Input.GetAxis("Horizontal") != 0)
            {
                anim.SetBool("WolfWalk", false);
                anim.SetBool("WolfJump", true);
            }


            else
            {
                anim.SetBool("WolfJump", false);
            }



        }
    }

    private void TransitionAnimations()
    {
        if (_playerTransformation.wolfToHumanTransition)
        {
            anim.SetBool("WolfIdle", false);
            anim.SetBool("WolfToHuman", true);
        }

        else if (_playerTransformation.humanToWolfTransition)
        {
            anim.SetBool("HumanIdle", false);
            anim.SetBool("HumanToWolf", true);
        }
    }

    private void TransformationAnimations()
    {
        if (_playerTransformation.wolfMode)
        {
            if (!_runOnce)
            {
                anim.SetBool("WolfIdle", true);
                _runOnce = true;
            }
            anim.SetBool("HumanIdle", false);
            anim.SetBool("HumanToWolf", false);
        }


        else if (!_playerTransformation.wolfMode)
        {
            if (!_runOnce)
            {
                anim.SetBool("HumanIdle", true);
                _runOnce = true;
            }
            anim.SetBool("WolfToHuman", false);
            anim.SetBool("WolfIdle", false);

        }
    }

    private void WolfAtackAnimations()
    {
        if (_playerTransformation.wolfMode && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(PlayAnimationComplete(0f));
            Debug.Log("wolf atack");



        }
    }
    IEnumerator PlayAnimationComplete(float secondsToWait)
    {
        AtackingAni = true;
        float finished = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        while (finished <= 1)
        {
            anim.SetBool("WolfIdle", false);
            anim.SetBool("WolfAtack", true);

        }
        anim.SetBool("WolfIdle", true);
        anim.SetBool("WolfAtack", false);
        AtackingAni = false;

    }

}
