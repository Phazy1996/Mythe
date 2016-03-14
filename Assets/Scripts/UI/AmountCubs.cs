using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmountCubs : MonoBehaviour
{

    [SerializeField]
    private GameObject _cubsTextObj;
    private Text _cubsText;

    [SerializeField]
    private int _cubsAmount = 0;

    // Use this for initialization
    void Start()
    {
        _cubsText = _cubsTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _cubsText.text = _cubsAmount + " /50";

    }

}