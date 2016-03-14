using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectablesText : MonoBehaviour {

    //GameObject
    [SerializeField]
    private GameObject _collectablesTextObject;
    private GameObject[] _sonObject;
    //GameObject

    [SerializeField]
    private float _collectableAmount = 0;

    //Text
    private Text _collectablesText;
    //Text

    //Scripts
    private SonCollectable _sonCollectable;
    //Scripts

    void Start()
    {
        _collectablesText = _collectablesTextObject.GetComponent<Text>();
       _collectablesTextObject.SetActive(false);
        _sonObject = GameObject.FindGameObjectsWithTag(GameTags.son);
        

        foreach (GameObject son in _sonObject)
        _sonCollectable = son.GetComponent<SonCollectable>();
    }
	

	void Update ()
    {
        if (_sonCollectable.addSon == true)
        {
            _sonObject = GameObject.FindGameObjectsWithTag(GameTags.son);

            foreach (GameObject son in _sonObject)
            StartCoroutine("AddSon");
        }
	}

    private IEnumerator AddSon()
    {
        _sonObject = GameObject.FindGameObjectsWithTag(GameTags.son);
        _sonCollectable.addSon = false;
        print("Work");
        _collectableAmount+= 1;
        
        _collectablesText.text = _collectableAmount + " / 50";
        _collectablesTextObject.SetActive(true);

        foreach (GameObject son in _sonObject)
        
        
        

        yield return new WaitForSeconds(2);
        
        _collectablesTextObject.SetActive(false);
    }
}
