using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public GameObject infoPanel;
    private Animator animator;
    private Vector3 originalScale;

    private void Start()
    {
        animator = GetComponent<Animator>(); // Get Animator
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        BringToFront();
        animator.ResetTrigger("Selected");
        animator.SetTrigger("Selected"); // Play animation
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //infoPanel.SetActive(false);
        animator.ResetTrigger("Finished");
        animator.SetTrigger("Finished");
        transform.localScale = originalScale;
    }

    private void BringToFront()
    {
        transform.SetAsLastSibling();
        //infoPanel.SetActive(true);
        transform.localScale = originalScale * 1.1f;
    }
}