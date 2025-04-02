using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    private AudioSource sel;
    private static GameObject lastSelected;

    void Start()
    {
        sel = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Si no hay ning�n objeto seleccionado, restaurar el �ltimo bot�n seleccionado
        if (EventSystem.current.currentSelectedGameObject == null && lastSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelected);
        }
    }

    // When selected by keyboard/controller
    public void OnSelect(BaseEventData eventData)
    {
        sel.Play();
        lastSelected = gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sel.Play();
        EventSystem.current.SetSelectedGameObject(null); // Desactivar selecci�n al usar el rat�n
    }
}
