using UnityEngine;
using TMPro;
using System.Collections;

public class FadeTextByCharacter : MonoBehaviour
{
    public float delayPerCharacter = 0.05f;
    public GameObject nextTextObject;

    public int textNumber = 0;
    public GameObject zack;
    public GameObject zoey;
    public GameObject enemigo;
    public GameObject enemyHealth;
    public GameObject playerHealth;
    public GameObject textoPelea;
    public MenuManager menuManager;


    private TextMeshProUGUI textMesh;
    private bool textFinished = false;
    private bool waitingForInput = false;

    void OnEnable()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        if (textMesh != null)
        {
            textMesh.ForceMeshUpdate();
            textMesh.maxVisibleCharacters = 0;
            StartCoroutine(RevealCharacters());
        }
    }

    IEnumerator RevealCharacters()
    {
        int totalCharacters = textMesh.textInfo.characterCount;

        for (int i = 0; i <= totalCharacters; i++)
        {
            textMesh.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delayPerCharacter);
        }

        textFinished = true;
        waitingForInput = true;
    }

    void Update()
    {

        if(textNumber == 0)
        {
            enemigo.SetActive(true);
            zack.SetActive(false);
            zoey.SetActive(false);
            enemyHealth.SetActive(false);
            playerHealth.SetActive(false);
        }

        if (textNumber == 1)
        {
            enemigo.SetActive(false);
            zack.SetActive(true);
            zoey.SetActive(true);
            enemyHealth.SetActive(false);
            playerHealth.SetActive(false);
        
        }

        if (textNumber == 2) {
            enemigo.SetActive(false);
            zack.SetActive(true);
            zoey.SetActive(true);
            enemyHealth.SetActive(false);
            playerHealth.SetActive(false);
        
        }

        if (textNumber == 3) { 
        
            zack.SetActive(false);
            zoey.SetActive(false);
            enemigo.SetActive(true);
            menuManager.panel.SetActive(true);
            menuManager.menuInicial.SetActive(true);
            enemyHealth.SetActive(true);
            playerHealth.SetActive(true);
            textoPelea.SetActive(false);
        }

        if (waitingForInput && Input.GetKeyDown(KeyCode.Return))
        {
            waitingForInput = false;

            if (nextTextObject != null)
            {
                nextTextObject.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}
