using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

                Instantiate(teclas[random]);
                timeBetween = startTime;
            }
            else
            {
                timeBetween -= Time.deltaTime;
            }
    }
}
