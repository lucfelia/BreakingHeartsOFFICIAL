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
    private AudioSource au;

    private void Start()
    {
        animator = GetComponent<Animator>();
        au = GetComponent<AudioSource>();
        currentPosition = transform.position;
        currentPosition = GameManager.Instance.GetSavedPosition();
        SetTargetIndex(GameManager.Instance.GetSavedTargetIndex());
    }

    void Update() {
        //Si se pulsa tecla derecha o arriba se suma el indice
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) 
            || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            spritePlayer.flipX = false;
            targetIndex++;
            if (targetIndex >= GameManager.Instance.lvlsUnblocked)
            {
                targetIndex = GameManager.Instance.lvlsUnblocked;
            }
            target = targets[targetIndex];
        }
        //Si se pulsa tecla izquierda o abajo se resta el indice
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) 
            || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            spritePlayer.flipX = true;
            targetIndex--;
            if (targetIndex < 0)
            {
                targetIndex = 0;
            }
            target = targets[targetIndex];
        }
        GameManager.Instance.SavePlayerData(transform.position, targetIndex);
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
            au.Play();
            onNode = false;
        }
    }
    public void SetTargetIndex(int index)
    {
        targetIndex = index;

        if (targetIndex >= 0 && targetIndex < targets.Count)
        {
            target = targets[targetIndex];
        }
    }
}
