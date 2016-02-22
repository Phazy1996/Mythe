using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{

    //Floats
    [SerializeField] private float _camFollowVelocity;
    private float minDistance;
    private float followDistance;

    [SerializeField] private float _cameraMagnitudeVel = 10f;
    //Floats

    //GameObject
    [SerializeField] private GameObject _cameraTarget;
    //GameObject

    //Vector3
    private Vector3 offset;
    private Vector3 _cameraTargetPos;
    //Vector3

    void Start()
    {
        offset = Vector3.zero;
        _cameraTargetPos = transform.position;
    }


    void FixedUpdate()
    {
        FollowCamera();
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

            transform.position = Vector3.Lerp(transform.position, _cameraTargetPos + offset, 0.25f);

        }
    }
}