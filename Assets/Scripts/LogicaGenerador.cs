using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGenerador : MonoBehaviour
{

    public GameObject[] teclas;
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
            random = Random.Range(0, teclas.Length);
            Instantiate(teclas[random], transform.position, Quaternion.identity);
            timeBetween = startTime;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
