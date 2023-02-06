using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataController.instance.RefreshData();
    }

 
}
