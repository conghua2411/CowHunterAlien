using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    [SerializeField]
    private float width;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width)
        {
            MoveBackground();
        }
    }

    private void MoveBackground()
    {
        transform.position = transform.position + new Vector3(2*width, 0f);
    }
}
