using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    public int vidaActual;
    public int vidaMax;
    public UnityEvent<int> cambioVida;

    public MenuManager MenuManager;

    // Start is called before the first frame update
    private void Start() {
        vidaActual = vidaMax;
        cambioVida.Invoke(vidaActual);
    }

    public void TomarDa�o(int cantidadDa�o) {
        int vidaTemporal = vidaActual - cantidadDa�o;
        
        if (vidaTemporal < 0) { vidaActual = 0; } 
        else { vidaActual = vidaTemporal; }
        cambioVida.Invoke(vidaActual);
        if (vidaTemporal <= 0) {
            if (MenuManager != null) { MenuManager.AbrirMenuGameover(); }
        }
    }
    public void CurarVida (int cantidadCuracion) {
        int vidaTemporal = vidaActual + cantidadCuracion;

        if (vidaTemporal > vidaMax) { vidaActual = vidaMax; }
        else { vidaActual = vidaTemporal; }
        cambioVida.Invoke(vidaActual);
    }
}
