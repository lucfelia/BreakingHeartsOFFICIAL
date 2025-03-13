using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float alpha = 1.0f;

    // Start is called before the first frame update
    void Start() {
        GameManager.Instance.lvlsUnblocked.Add(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
