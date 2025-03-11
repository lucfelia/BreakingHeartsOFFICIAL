using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    public int vidaActual;
    public int vidaMax;
    public UnityEvent<int> cambioVida;

    public MenuManager MenuManager;

    public GameObject damageFlash;
    private Camera mainCamera;
    private Vector3 originalCamPosition;

    private float shakeTime = 0;
    private float flashTime = 0;

    // Start is called before the first frame update
    private void Start() {
        vidaActual = vidaMax;
        cambioVida.Invoke(vidaActual);

        mainCamera = Camera.main;
        if (mainCamera) originalCamPosition = mainCamera.transform.position;
    }

    private void Update()
    {
        //screen shake
        if (shakeTime > 0)
        {
            mainCamera.transform.position = originalCamPosition + (Vector3)Random.insideUnitCircle * 0.1f;
            shakeTime -= Time.deltaTime;
        }
        else if (mainCamera.transform.position != originalCamPosition) // Reset camera position
        {
            mainCamera.transform.position = originalCamPosition;
        }

        //red flash
        if (flashTime > 0)
        {
            flashTime -= Time.deltaTime;
        }
        else if (damageFlash && damageFlash.activeSelf)
        {
            damageFlash.SetActive(false);
        }
    }

    public void TomarDaño(int cantidadDaño) {
        int vidaTemporal = vidaActual - cantidadDaño;
        
        if (vidaTemporal < 0) { vidaActual = 0; } 
        else { vidaActual = vidaTemporal; }
        cambioVida.Invoke(vidaActual);

        if (vidaTemporal <= 0) {
            if (MenuManager != null) { MenuManager.AbrirMenuGameover(); }
        }
        shakeTime = 0.5f;
        flashTime = 0.3f;

        if (damageFlash) damageFlash.SetActive(true);
    }
    public void CurarVida (int cantidadCuracion) {
        int vidaTemporal = vidaActual + cantidadCuracion;

        if (vidaTemporal > vidaMax) { vidaActual = vidaMax; }
        else { vidaActual = vidaTemporal; }
        cambioVida.Invoke(vidaActual);
    }
}
