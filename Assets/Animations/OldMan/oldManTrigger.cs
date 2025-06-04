using UnityEngine;

public class oldManTrigger : MonoBehaviour
{
    private Animator anim;
    private string fall = "isFalling";

    public GameObject dialogueBox;
    public GameObject pressE;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        anim.SetBool(fall, false);
        dialogueBox.SetActive(false);
        pressE.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
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
                Invoke("StartDialogue", 1.25f);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (dialogueBox == null) {
                pressE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (dialogueBox == null) {
                pressE.SetActive(false);
            }
        }
    }

    private void StartDialogue()
    {
        dialogueBox.SetActive(true);
    }
}