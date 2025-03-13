using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<int> lvlsUnblocked = new List<int>();

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }else
        {
            Debug.Log("Warning: multiple" + this + "in scene!");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        lvlsUnblocked.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
