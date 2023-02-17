using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// makes text messeges ingame, works by hiding the sprites on the z axis
/// </summary>
public class TextTriggerCtrl : MonoBehaviour
{
    public GameObject background;
    public Text text;

    private SpriteRenderer backgroundSR;
    // Start is called before the first frame update
    void Start()
    {
        backgroundSR = background.GetComponent<SpriteRenderer>();
        backgroundSR.color = new Color(1, 1, 1, 0);
        text.color = new Color(1, 1, 1, 0);
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            backgroundSR.color = new Color(0.09433961f, 0.0467248f, 0.0467248f, 0.5f);
            text.color = new Color(1, 1, 1, 1);
        }
        
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.color = new Color(1, 1, 1, 0);
        backgroundSR.color = new Color(1, 1, 1, 0);
        
    }
}
