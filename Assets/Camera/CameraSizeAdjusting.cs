using UnityEngine;
using System.Collections;

public class CameraSizeAdjusting : MonoBehaviour {

    //Floats
    private float _camSize;
    private float _regCamSizeToUse = 5f;

    [SerializeField] private float _camSizeToChangeTo;
   // [SerializeField] private float _overlapCircleSize = 2f;
    [SerializeField] private float _zoomSpeed = 2f;
    //Floats

    //GameObjects
    [SerializeField] private GameObject _mainCamGameObject;
    //GameObjects

    //LayerMasks
    [SerializeField] private LayerMask _playerLayer;
    //LayerMasks

    //Camera
    private Camera _mainCam;
    //Camera
    
    //Bool
    private bool _zoomIn = false;
    private bool _zoomOut = false;
    //Bool

    

	void Start () 
    {
        _mainCam = _mainCamGameObject.GetComponent<Camera>();
        _camSize = _mainCam.orthographicSize;
	}
	

	void Update () 
    {
        // CheckPlayer();

        AdjustCamera();
        RevertCamera();
	}

    /*
    private void CheckPlayer()
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(this.gameObject.transform.position, _overlapCircleSize, _playerLayer);


        float shortestDistance = float.MaxValue;


        for (int i = 0; i < playerCollider.Length; i++)
        {
            float distance = Vector2.Distance(this.gameObject.transform.position, playerCollider[i].transform.position);

            if (distance < shortestDistance)
            {
                _playerObject = playerCollider[i].gameObject;
                shortestDistance = distance;
            }
            
        }
     

       

        if (_playerObject != null)
        {
            AdjustCamera();
           
        }
    }
     
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, _overlapCircleSize);
    }
     */

    
    private void AdjustCamera()
    {
        if (_zoomIn)
        {
            if (_camSize <= _camSizeToChangeTo)
            {
                _camSize += _zoomSpeed * Time.deltaTime;

                _mainCam.orthographicSize = _camSize;
            }
        }
       
        
    }

    private void RevertCamera()
    {
        if(_zoomOut)
        {
            if (_camSize >= _regCamSizeToUse)
            {
                _camSize -= _zoomSpeed * Time.deltaTime;
                _mainCam.orthographicSize = _camSize;
            }
        }
     
            

    }

 
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == GameTags.player)
        {
            _zoomOut = false;
            _zoomIn = true;
        }
           
    }

    void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.tag == GameTags.player)
        {
            _zoomOut = true;
            _zoomIn = false;
        }

    }


}
