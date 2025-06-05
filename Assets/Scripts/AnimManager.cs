using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimManager : MonoBehaviour
{
    public GameObject[] panels;

    public static AnimManager AnimInstance { get; private set; }
    void Awake()
    {
        if (AnimInstance == null)
        {
            AnimInstance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }
}