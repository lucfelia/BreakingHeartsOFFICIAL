using UnityEngine;

public class AnimManager : MonoBehaviour
{
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