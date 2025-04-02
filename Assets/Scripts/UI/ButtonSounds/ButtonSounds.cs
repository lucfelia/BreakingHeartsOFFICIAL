using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, ISelectHandler
{
    private AudioSource sel;

    void Start()
    {
        sel = GetComponent<AudioSource>();
    }

    // When selected by keyboard/controller
    public void OnSelect(BaseEventData eventData)
    {
        sel.Play();
    }  
}
