using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SoundSelection : MonoBehaviour
{
    public AudioSource clickSound;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {
        clickSound.Play();
    }
}
