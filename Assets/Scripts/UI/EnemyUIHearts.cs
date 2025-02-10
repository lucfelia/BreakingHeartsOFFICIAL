using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EnemyUIHearts : MonoBehaviour
{
    public List<Image> listaCorazonesEnemigo;
    public GameObject corazonPrefab;
    public EnemyLife EnemyLife;
    public int IndexActualEnemigo;
    public Sprite corazonLlenoEnemigo;
    public Sprite corazonVacioEnemigo;

    private void Awake()
    {
        EnemyLife.cambioVidaEnemigo.AddListener(CambiarCorazonesEnemigo);

    }
    private void CambiarCorazonesEnemigo(int vidaActualEnemigo)
    {
        if (!listaCorazonesEnemigo.Any()) { CrearCorazonesEnemigo(vidaActualEnemigo); }
        else { CambiarVidaEnemigo(vidaActualEnemigo); }
    }
    private void CrearCorazonesEnemigo(int cantidadMaxVidaEnemigo)
    {
        for (int i = 0; i < cantidadMaxVidaEnemigo; i++)
        {
            GameObject corazon = Instantiate(corazonPrefab, transform);
            listaCorazonesEnemigo.Add(corazon.GetComponent<Image>());
        }
        IndexActualEnemigo = cantidadMaxVidaEnemigo - 1;
    }
    private void CambiarVidaEnemigo(int vidaActualEnemigo)
    {
        if (vidaActualEnemigo <= IndexActualEnemigo)
        {
            QuitarCorazonesEnemigo(vidaActualEnemigo);
        }
        else
        {
            AgregarCorazonesEnemigo(vidaActualEnemigo);
        }
    }
    private void QuitarCorazonesEnemigo(int vidaActual)
    {
        for (int i = IndexActualEnemigo; i >= vidaActual; i--)
        {
            IndexActualEnemigo = i;
            listaCorazonesEnemigo[IndexActualEnemigo].sprite = corazonVacioEnemigo;
        }
    }
    private void AgregarCorazonesEnemigo(int vidaActual)
    {
        for (int i = IndexActualEnemigo; i < vidaActual; i++)
        {
            IndexActualEnemigo = i;
            listaCorazonesEnemigo[IndexActualEnemigo].sprite = corazonLlenoEnemigo;
        }
    }
}
