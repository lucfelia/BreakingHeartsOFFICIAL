using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.UI;

public class HoverDeVideos : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject hoverPanel;
    public VideoPlayer player;
    public Button botonDefault;

    void Start()
    {
        hoverPanel.SetActive(false);
        player.SetDirectAudioMute(0, true);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(botonDefault.interactable == true)
        {
        hoverPanel.SetActive(true);
        player.Play();
        }

    }


    public void OnPointerExit(PointerEventData eventData)
    {
        
        hoverPanel.SetActive(false);
        player.Stop();
        
    }
}
