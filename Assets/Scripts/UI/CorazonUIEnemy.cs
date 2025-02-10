using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CorazonUIEnemy : MonoBehaviour
{
    public List<Image> listaCorazones;
    public GameObject corazonPrefab;
    public VidaEnemigo vidaEnemigo;
    public int IndexActual;
    public Sprite corazonLleno;
    public Sprite corazonVacio;

    private void Awake() {
        vidaEnemigo.cambioVida.AddListener(CambiarCorazones);

    }
    private void CambiarCorazones(int vidaActual) {
        if (!listaCorazones.Any()) { CrearCorazones(vidaActual); }
        else { CambiarVida(vidaActual); }
    }
    private void CrearCorazones(int cantidadMaxVida) {
        for (int i = 0; i < cantidadMaxVida; i++) {
            GameObject corazon = Instantiate(corazonPrefab, transform);
            listaCorazones.Add(corazon.GetComponent<Image>());
        }
        IndexActual = cantidadMaxVida - 1;
    }
    private void CambiarVida(int vidaActual) {
        if (vidaActual <= IndexActual) {
            QuitarCorazones(vidaActual);
        }
        else
        {
            AgregarCorazones(vidaActual);
        }
    }
    private void QuitarCorazones(int vidaActual)
    {
        for (int i = IndexActual; i >= vidaActual; i--) {
            IndexActual = i;
            listaCorazones[IndexActual].sprite = corazonVacio;
        }
    }
    private void AgregarCorazones(int vidaActual)
    {
        for (int i = IndexActual; i < vidaActual; i++) {
            IndexActual = i;
            listaCorazones[IndexActual].sprite = corazonLleno;
        }
    }
}
