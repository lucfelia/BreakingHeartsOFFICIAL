using UnityEngine;

public class ShadowTrigger : MonoBehaviour
{
    private Transform animParent;
    private GameObject dialogueBox;
    public GameObject pressE;

    // Start is called before the first frame update
    void Start()
    {
        animParent = GameObject.Find("AllTexts-SelectLvl").transform;
        if (animParent != null) {
            Transform panelTransform = animParent.Find("ShadowPanel");
            if (panelTransform != null)
            {
                dialogueBox = panelTransform.gameObject;
                dialogueBox.SetActive(false);
            }
        }

        pressE.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dialogueBox == null)
            {
                pressE.SetActive(true);
            }
            else
            {
                pressE.SetActive(false);
                Invoke("StartDialogue", 1f);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dialogueBox == null)
            {
                pressE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dialogueBox == null)
            {
                pressE.SetActive(false);
            }
        }
    }

    private void StartDialogue()
    {
        dialogueBox.SetActive(true);
    }
}