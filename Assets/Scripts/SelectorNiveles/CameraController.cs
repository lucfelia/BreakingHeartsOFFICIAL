using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float alpha = 1.0f;

    public GameObject target = null;

    private Vector2 targetPosition;
    private Vector2 currentPosition;

    void FixedUpdate() {
        if(target != null) {
            targetPosition = target.transform.position;
            currentPosition = transform.position;

            transform.position = Vector2.Lerp(currentPosition, targetPosition, alpha * Time.deltaTime);
            Vector3 pos = transform.position;
            pos.z = -1;
            transform.position = pos;
        }
    }
}
