using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// makes text messeges ingame, works by hiding the sprites on the z axis
/// </summary>
public class TextTriggerCtrl : MonoBehaviour
{
    public Transform textBaner;
    public Transform textMessege;
    // Start is called before the first frame update
    void Start()
    {
        textBaner.transform.position = new Vector3(textBaner.transform.position.x, textBaner.transform.position.y, -50);
        textMessege.transform.position = new Vector3(textMessege.transform.position.x, textMessege.transform.position.y, -50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        textBaner.transform.position = new Vector3(textBaner.transform.position.x, textBaner.transform.position.y, 1);
        textMessege.transform.position = new Vector3(textMessege.transform.position.x, textMessege.transform.position.y, 0);

    }
}
