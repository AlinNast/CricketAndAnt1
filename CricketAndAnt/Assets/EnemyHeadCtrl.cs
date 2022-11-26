using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadCtrl : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerFeet")
        {
            enemy.tag = "Untagged";
            Destroy(enemy);
            GameCtrl.instance.UpdateScoreCount(49);
        }
    }
}
