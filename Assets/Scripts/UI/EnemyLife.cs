using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    public MenuManager menuManager;

    public int vidaActualEnemigo;
    public int vidaMaxEnemigo;
    public UnityEvent<int> cambioVidaEnemigo;

    public GameObject damageFlash;
    private Vector3 originalCamPosition;

    private float shakeTime = 0;
    private float flashTime = 0;

    // Start is called before the first frame update
    private void Start()
    {
        vidaActualEnemigo = vidaMaxEnemigo;
        cambioVidaEnemigo.Invoke(vidaActualEnemigo);


        originalCamPosition = damageFlash.transform.position;
    }

    private void Update()
    {
        //screen shake
        if (shakeTime > 0)
        {
            damageFlash.transform.position = originalCamPosition + (Vector3)Random.insideUnitCircle * 0.1f;
            shakeTime -= Time.deltaTime;
        }
        else if (damageFlash.transform.position != originalCamPosition) // Reset camera position
        {
            damageFlash.transform.position = originalCamPosition;
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

    public void TomarDañoEnemigo(int cantidadDañoEnemigo)
    {
        int vidaTemporalEnemigo = vidaActualEnemigo - cantidadDañoEnemigo;

        if (vidaTemporalEnemigo < 0) { vidaActualEnemigo = 0; }
        else { vidaActualEnemigo = vidaTemporalEnemigo; }
        cambioVidaEnemigo.Invoke(vidaActualEnemigo);

        shakeTime = 0.5f;
        flashTime = 0.3f;

        if (damageFlash) damageFlash.SetActive(true);

        if (vidaTemporalEnemigo <= 0)
        {
            Debug.Log("Enemigo vencido!");
            GameManager.Instance.CompleteLevel(LevelController.Instance.targetIndex);
            menuManager.AbrirMenuLvlClear();
        }
    }
}