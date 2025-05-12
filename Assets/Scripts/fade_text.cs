using UnityEngine;
using TMPro;
using System.Collections;

public class FadeTextByCharacter : MonoBehaviour
{
    public float delayPerCharacter = 0.05f;
    public GameObject nextTextObject;

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
