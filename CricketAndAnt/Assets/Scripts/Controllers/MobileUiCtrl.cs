using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUiCtrl : MonoBehaviour
{
    public GameObject player;
    PlayerCtrl playerCtrl;
    

    void Start()
    {
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    
    public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }
    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();
    }
    public void MobileStop()
    {
        playerCtrl.MobileStop();
    }
    public void MobileJump()
    {
        playerCtrl.MobileJump();
    }
    public void MobileShoot()
    {
        playerCtrl.MobileShoot();
    }

}
