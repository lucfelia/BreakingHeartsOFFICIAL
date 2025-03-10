using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPalos : MonoBehaviour
{

    float smooth = 50.0f;
    float tiltAngle = 79.63f;
    public float beatTime = 0.10f;
    public float time = 0f;

    // Update is called once per frame
    void Update()
    {
        time += 0.1f;

        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, 30 * smooth);

        if (time == beatTime)
        {
            time = 0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Tambor");

        if (time <= 0.3f)
        {
            Debug.Log("EARLY");
        }
        else if (time >= 0.4f || time < 0.6f)
        {
            Debug.Log("PERFECT");
        }
        else
        {
            Debug.Log("LATE");
        }

    }

}
