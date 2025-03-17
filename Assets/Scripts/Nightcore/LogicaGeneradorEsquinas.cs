using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGeneradorEsquinas : MonoBehaviour
{
    public GameObject[] teclasEsquinas;
    private float timeBetween;
    public float startTime;
    public int random;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetween <= 0)
        {
            random = UnityEngine.Random.Range(0, teclasEsquinas.Length);

            if (teclasEsquinas[random] == teclasEsquinas[0])
            {
                teclasEsquinas[0].transform.position = new Vector3(-9.4f, 5.5f);
            }
            else if (teclasEsquinas[random] == teclasEsquinas[1])
            {
                teclasEsquinas[1].transform.position = new Vector3(-9.4f, -5.5f);
            }
            else if (teclasEsquinas[random] == teclasEsquinas[2])
            {
                teclasEsquinas[2].transform.position = new Vector3(9.4f, -5.5f);
            }
            else if (teclasEsquinas[random] == teclasEsquinas[3])
            {
                teclasEsquinas[3].transform.position = new Vector3(9.4f, 5.5f);
            }

            Instantiate(teclasEsquinas[random]);
            timeBetween = startTime;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
