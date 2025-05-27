using UnityEngine;

public class LogicaGenerador : MonoBehaviour
{
    public GameObject[] teclas;
    private float timeBetween;
    public float startTime;
    public int random;

    //Padre de las teclas
    public Transform contenedorTeclas;

    // Update is called once per frame
    void Update()
    {
            if (timeBetween <= 0)
            {
                random = UnityEngine.Random.Range(0, teclas.Length);

                if (teclas[random] == teclas[0])
                {
                    teclas[0].transform.position = new Vector3(-3, 6);
                }
                else if (teclas[random] == teclas[1])
                {
                    teclas[1].transform.position = new Vector3(-1, 6);
                }
                else if (teclas[random] == teclas[2])
                {
                    teclas[2].transform.position = new Vector3(1, 6);
                }
                else if (teclas[random] == teclas[3])
                {
                    teclas[3].transform.position = new Vector3(3, 6);
                }

                Instantiate(teclas[random], contenedorTeclas);
                timeBetween = startTime;
            }
            else
            {
                timeBetween -= Time.deltaTime;
            }
    }
}
