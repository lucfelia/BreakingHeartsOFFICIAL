using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    private string hoverTrigger = "Hover";
    private string normalState = "Normal";
    private bool isSelected;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Trigger hover animation
        animator.SetTrigger(hoverTrigger);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert to normal state animation
        animator.SetTrigger(normalState);
    }
    void Update()
    {
        // Obtener el objeto seleccionado actualmente en el sistema de eventos
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        // Si el objeto padre está seleccionado, activar la animación
        if (selectedObject != null && selectedObject.transform == transform.parent)
        {
            if (!isSelected)
            {
                animator.SetTrigger(hoverTrigger);
                isSelected = true;
            }
        }
        else
        {
            if (isSelected)
            {
                animator.SetTrigger(normalState);
                isSelected = false;
            }
        }
    }
}