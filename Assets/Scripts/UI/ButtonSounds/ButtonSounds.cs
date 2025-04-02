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
        // Si no hay ningún objeto seleccionado, restaurar el último botón seleccionado
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
        EventSystem.current.SetSelectedGameObject(null); // Desactivar selección al usar el ratón
    }
}
