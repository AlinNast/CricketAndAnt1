using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnCtrl : MonoBehaviour
{
    public void SaveData()
    {
        DataController.instance.SaveData();
    }
}
