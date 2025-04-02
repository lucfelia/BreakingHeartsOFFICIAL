using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    private string hoverTrigger = "Hover";
    private string normalState = "Normal";

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
}