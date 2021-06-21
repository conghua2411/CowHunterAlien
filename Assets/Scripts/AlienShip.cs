using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour
{

    private BoxCollider2D shipCollider;

    private float startRay = 0;

    private void Start()
    {
        shipCollider = GetComponent<BoxCollider2D>();

        startRay = transform.position.y + shipCollider.size.y + 5;
    }

    private void ShipPull()
    {
        Debug.DrawRay(transform.position, Vector3.down * 10, Color.yellow);

        RaycastHit2D hitInfo = Physics2D.Raycast(new Vector3(0, 1, 0), Vector3.down);

        if (hitInfo)
        {
            if (hitInfo.transform.tag == "cow")
            {
                //hitInfo.transform.GetComponent<Cow>().Capture();

                Cow cow = hitInfo.transform.GetComponent<Cow>();

                if (cow != null)
                {
                    cow.Capture(transform.position.y - 1f);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGamePlay())
        {
            return;
        }

        if (Input.GetButton("Jump"))
        {
            ShipPull();
        }

        if (Input.GetButtonUp("Jump"))
        {
            ShipRelease();
        }
    }

    private void ShipRelease()
    {
        Debug.DrawRay(transform.position, Vector3.down * 100, Color.yellow);

        RaycastHit2D hitInfo = Physics2D.Raycast(new Vector3(0, 1, 0), Vector3.down);

        if (hitInfo)
        {
            if (hitInfo.transform.tag == "cow")
            {
                Cow cow = hitInfo.transform.GetComponent<Cow>();

                if (cow != null)
                {
                    cow.Release();
                }
            }
        }
    }
}
