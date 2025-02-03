using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float alpha = 1.0f;

    public GameObject target = null;

    public List<GameObject> targets = new List<GameObject>();
    private int targetIndex = 0;

    private Vector2 targetPosition;
    private Vector2 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            targetIndex++;
            if (targetIndex >= targets.Count)
            {
                targetIndex = 0;
            }
            target = targets[targetIndex];
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null){
            targetPosition = target.transform.position;
            currentPosition = transform.position;

            transform.position = Vector2.Lerp(currentPosition, targetPosition, alpha * Time.deltaTime);
        }
    }
}
