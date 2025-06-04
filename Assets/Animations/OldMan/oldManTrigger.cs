using UnityEngine;

public class oldManTrigger : MonoBehaviour
{
    private Animator anim;
    private string fall = "isFalling";

    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        anim.SetBool(fall, false);
        dialogueBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        { 
            anim.SetBool(fall, true);
            Invoke("StartDialogue", 1.25f);
        }
    }

    private void StartDialogue()
    {
        dialogueBox.SetActive(true);
    }
}