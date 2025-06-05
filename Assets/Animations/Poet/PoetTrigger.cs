using UnityEngine;

public class PoetTrigger : MonoBehaviour
{
    private Animator anim;
    private string fall = "isFalling";

    private Transform animParent;
    private GameObject dialogueBox;
    public GameObject pressE;

    // Start is called before the first frame update
    void Start()
    {
        animParent = GameObject.Find("AllTexts-SelectLvl").transform;
        if (animParent != null) {
            Transform panelTransform = animParent.Find("PoetPanel");
            if (panelTransform != null)
            {
                dialogueBox = panelTransform.gameObject;
                dialogueBox.SetActive(false);
            }
        }

        anim = GetComponent<Animator>();
        anim.SetBool(fall, false);
        pressE.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool(fall, true);
            if (dialogueBox == null)
            {
                pressE.SetActive(true);
            }
            else
            {
                pressE.SetActive(false);
                Invoke("StartDialogue", 1.75f);
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