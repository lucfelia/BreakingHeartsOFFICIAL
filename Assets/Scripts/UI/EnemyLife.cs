using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    public int vidaActualEnemigo;
    public int vidaMaxEnemigo;
    public UnityEvent<int> cambioVidaEnemigo;

    // Start is called before the first frame update
    private void Start()
    {
        vidaActualEnemigo = vidaMaxEnemigo;
        cambioVidaEnemigo.Invoke(vidaActualEnemigo);
    }

    public void TomarDa�oEnemigo(int cantidadDa�oEnemigo)
    {
        int vidaTemporalEnemigo = vidaActualEnemigo - cantidadDa�oEnemigo;

        if (vidaTemporalEnemigo < 0) { vidaActualEnemigo = 0; }
        else { vidaActualEnemigo = vidaTemporalEnemigo; }
        cambioVidaEnemigo.Invoke(vidaActualEnemigo);
        if (vidaTemporalEnemigo <= 0)
        {
            SceneManager.LoadScene("SelectorDeNiveles");
        }
    }
}