using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float alpha = 1.0f;

    public GameObject target = null;

    public List<GameObject> targets = new List<GameObject>();
    private int targetIndex = 0;

    private Vector2 targetPosition;
    private Vector2 currentPosition;

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            targetIndex++;
            if (targetIndex >= GameManager.Instance.lvlsUnblocked)
            {
                targetIndex = GameManager.Instance.lvlsUnblocked;
            }
            target = targets[targetIndex];
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            targetIndex--;
            if (targetIndex < 0)
            {
                targetIndex = 0;
            }
            target = targets[targetIndex];
        }
    }

    void FixedUpdate() {
        if(target != null) {
            targetPosition = target.transform.position;
            currentPosition = transform.position;

            transform.position = Vector2.Lerp(currentPosition, targetPosition, alpha * Time.deltaTime);
        }
    }
}
