using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float boundary = 10f;

    private int direction = 1;

    private bool isCaptured = false;

    private Rigidbody2D cowBody;

    private float maxHeight;

    private bool _moving = false;

    private void Start()
    {
        cowBody = GetComponent<Rigidbody2D>();
    }

    void OnBecameInvisible()
    {
        Release();
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        CheckDirection();
    }

    private void CheckDirection()
    {
        if (transform.position.x >= boundary)
            direction = -1;

        if (transform.position.x <= -boundary)
            direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGamePlay())
        {
            return;
        }

        if (isCaptured)
        {
            if (transform.position.y <= maxHeight)
            {
                transform.position += transform.up * Time.deltaTime * speed;
            }
            return;
        }

        if (_moving)
        {
            transform.position += transform.right * Time.deltaTime * direction * speed;
        }
    }

    public void Capture()
    {
        cowBody.gravityScale = 0;
        isCaptured = true;
    }

    public void Capture(float max)
    {
        cowBody.velocity = Vector2.zero;
        maxHeight = max;

        Capture();
    }

    public void Release()
    {
        cowBody.gravityScale = 1;
        isCaptured = false;
    }
}
