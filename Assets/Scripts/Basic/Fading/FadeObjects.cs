using UnityEngine;
using System.Collections;

public class FadeObjects : MonoBehaviour {


    //Bool
    private bool _isfaded = false;
    //Bool

    //Float
    private float _alphaMin = 1f;
    //Float
    
    //Color
    private Color _realColor;
    //Color

    
    void Update()
    {
        SwitchFade();
    }

    private void SwitchFade()
    {
        if (_isfaded)
        {
            FadeOut();  
        }
        else
        {
            FadeIn();     
        }
    }

    private void FadeOut()
    {   
        if (_alphaMin > 0.5)
            _alphaMin -= 0.05f;

        _realColor = new Color(0f, 0f, 0f, _alphaMin);
        this.GetComponent<SpriteRenderer>().color = _realColor;

    }

    private void FadeIn()
    {
        if (_alphaMin <= 1)
            _alphaMin += 0.05f;

        _realColor = new Color(0f, 0f, 0f, _alphaMin);
        this.GetComponent<SpriteRenderer>().color = _realColor;
    }


    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == GameTags.player)
            _isfaded = true;          
    }

void OnTriggerExit2D(Collider2D player)
    {
        _isfaded = false;
    }
}
