using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{

    //Floats
    private float _camFollowVelocity;
    private float minDistance;
    private float followDistance;

    [SerializeField] private float _cameraMagnitudeVel = 10f;
    [SerializeField] private float _camFollowSpeed = 0.25f;

   [SerializeField] private float _shakeTimer = 1f;
   [SerializeField] private float _shakeAmount = 0.1f;
    //Floats

    //GameObject
    [SerializeField] private GameObject _cameraTarget;
    //GameObject

    //Vector3
    private Vector3 offset;
    private Vector3 _cameraTargetPos;
    //Vector3

    //Script
   // private PlayerMovement _playerScript;
    //Script

    void Start()
    {
       // _playerScript = _cameraTarget.GetComponent<PlayerMovement>();
        offset = new Vector3 (0F,.3F,0F);
        _cameraTargetPos = transform.position;
    }


    void FixedUpdate()
    {
        FollowCamera();
       // ScreenShake();
       // ShakeCamera(0.1f, 1f);
        
    }

    void Update()
    {
        
    }

    void FollowCamera()
    {
        if (_cameraTarget != null)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = _cameraTarget.transform.position.z;

            Vector3 _cameraTargetDirection = (_cameraTarget.transform.position - posNoZ);

            _camFollowVelocity = _cameraTargetDirection.magnitude * _cameraMagnitudeVel;

            _cameraTargetPos = transform.position + (_cameraTargetDirection.normalized * _camFollowVelocity * Time.deltaTime);
/*
            if (_playerScript._isGrounded)
            {
                _camFollowSpeed = 0.25f;
            }
            else
                _camFollowSpeed = 1f;
*/
            transform.position = Vector3.Lerp(transform.position, _cameraTargetPos + offset, _camFollowSpeed);


        }
    }

    void ScreenShake()
    {
        if (_shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * _shakeAmount;

            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.x + ShakePos.x);

            _shakeTimer -= Time.deltaTime;
        }
    }

    public void ShakeCamera(float shakePwr, float shakeDur)
    {
        _shakeAmount = shakePwr;
        _shakeTimer = shakeDur;
    }
}