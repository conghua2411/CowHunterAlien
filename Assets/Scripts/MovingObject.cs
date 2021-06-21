using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = new Vector2(-2f, 0);
    }
}
