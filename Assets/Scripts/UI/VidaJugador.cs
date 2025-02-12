using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    public int vidaActual;
    public int vidaMax;
    public UnityEvent<int> cambioVida;

    public ChangeMenu changeMenu;

    // Start is called before the first frame update
    private void Start() {
        vidaActual = vidaMax;
        cambioVida.Invoke(vidaActual);
    }

    public void TomarDaño(int cantidadDaño) {
        int vidaTemporal = vidaActual - cantidadDaño;
        
        if (vidaTemporal < 0) { vidaActual = 0; } 
        else { vidaActual = vidaTemporal; }
        cambioVida.Invoke(vidaActual);
        if (vidaTemporal <= 0) {
            if (changeMenu != null) { changeMenu.GameOver(); }
        }
    }
    public void CurarVida (int cantidadCuracion) {
        int vidaTemporal = vidaActual + cantidadCuracion;

        if (vidaTemporal > vidaMax) { vidaActual = vidaMax; }
        else { vidaActual = vidaTemporal; }
        cambioVida.Invoke(vidaActual);
    }
}
