using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingPlatform : MonoBehaviour
{
    public Transform Pos1, Pos2;

    public float speed;

    public Transform startPosition;

    public Vector3 nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == Pos1.position)
        {
            nextPosition = Pos2.position;
        }
        else if (transform.position == Pos2.position)
        {
            nextPosition = Pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed = Time.deltaTime);
    }
}
