using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoPalo : MonoBehaviour
{
    public float moveSpeed = 10f;
    public KeyCode hitKey;

    private Vector3 originalPosition;
    private bool isHitting = false;

    void Start()
    {

        originalPosition = transform.position;
    }

    void Update()
    {

        if (Input.GetKeyDown(hitKey))
        {
            isHitting = true;
        }


        if (Input.GetKeyUp(hitKey))
        {
            isHitting = false;
        }


        if (isHitting)
        {
            HitDrum();
        }
        else
        {
            ResetStickPosition();
        }

        if (transform.position.y <= -2f)
        {
            transform.position = originalPosition;
        }

    }

    void HitDrum()
    {

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void ResetStickPosition()
    {

        transform.position = originalPosition;
    }
}
