using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {


    //Scripts
    private PlayerTransformation _playerTransformation;
    private PlayerMovement _playerMovement;
    //Scripts

    //Animator
    Animator anim;
    //Animator


	void Start () 
    {
        _playerTransformation = this.gameObject.GetComponent<PlayerTransformation>();
        _playerMovement = this.gameObject.GetComponent<PlayerMovement>();


        anim = this.gameObject.GetComponent<Animator>();
	}
	

	void Update () 
    {
        TransformationAnimations();
	}

    private void TransformationAnimations()
    {
        if (_playerTransformation.wolfMode)
        {
            anim.SetBool("WolfIdle", true);
            anim.SetBool("HumanIdle", false);
        }
        else
        {
            anim.SetBool("HumanIdle", true);
            anim.SetBool("WolfIdle", false);
        }
    }
}
