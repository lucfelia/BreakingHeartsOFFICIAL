using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float alpha = 1.0f;

    public GameObject target = null;

    public List<GameObject> targets = new List<GameObject>();
    public int targetIndex = 0;
    public bool onNode = false;

    private Vector2 targetPosition;
    private Vector2 currentPosition;

    private Animator animator;
    private string jumpTrigger = "Jump";
    private string idleTrigger = "Idle";
    public SpriteRenderer spritePlayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            spritePlayer.flipX = false;
            targetIndex++;
            if (targetIndex >= GameManager.Instance.lvlsUnblocked)
            {
                targetIndex = GameManager.Instance.lvlsUnblocked;
            }
            target = targets[targetIndex];
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            spritePlayer.flipX = true;
            targetIndex--;
            if (targetIndex < 0)
            {
                targetIndex = 0;
            }
            target = targets[targetIndex];
        }
    }

    void FixedUpdate() {
        if(target != null) {
            targetPosition = target.transform.position;
            currentPosition = transform.position;

            transform.position = Vector2.Lerp(currentPosition, targetPosition, alpha * Time.deltaTime);
            Vector3 pos = transform.position;
            pos.z = -1;
            transform.position = pos;
        }
    }
    IEnumerator Deslizar()
    {
        yield return new WaitForSeconds(0.75f);
        animator.SetTrigger(idleTrigger);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plataform")) // Verifica si colisiona con la plataforma
        {  
            Debug.Log("Plataforma detectada");
            onNode = true;
            StartCoroutine(Deslizar());
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plataform")) // Verifica si colisiona con la plataforma
        {
            animator.SetTrigger(jumpTrigger);
            onNode = false;
        }
    }
}
