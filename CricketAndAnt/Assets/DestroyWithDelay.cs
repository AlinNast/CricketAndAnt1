using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys game object with delay
/// </summary>
public class DestroyWithDelay : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,delay);
    }
}
