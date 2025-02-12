using UnityEngine;
using TMPro;

public class LogicaTeclaUp : MonoBehaviour
{
    public float speed;
    public int counter = 0;
    public bool inside = false;
    float vertical;
    public float height = 0f;
    public GameObject Beat_Area;
    public LogicaJugador playerLogic;
    public GameObject hitTextPrefab, textHolder;

    // Start is called before the first frame update
    void Start()
    {
        vertical = -1f;
        textHolder = GameObject.Find("textHolder");
        if (textHolder != null) { Debug.Log("TextHolderDetected"); }

        Beat_Area = GameObject.Find("Beat_Area");
        if (Beat_Area != null) { playerLogic = Beat_Area.GetComponent<LogicaJugador>(); }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, vertical).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //verificar si la tecla esta dentro
        inside = (counter == 2 || counter == 3);

        if (transform.position.y <= -5.28f)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (inside)
            {
                if (counter == 2)
                {
                    if (transform.position.y > height)
                    {
                        GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
                        HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Early");
                        playerLogic.score += 2;
                        playerLogic.text.text = "Score: " + playerLogic.score.ToString();

                    }
                    else if (transform.position.y < height)
                    {
                        GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
                        HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Late");
                        playerLogic.score += 2;
                        playerLogic.text.text = "Score: " + playerLogic.score.ToString();
                    }
                }
                else
                {
                    GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
                    HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Excellent");
                    playerLogic.score += 4;
                    playerLogic.text.text = "Score: " + playerLogic.score.ToString();
                }
                Destroy(gameObject);
                Debug.Log("Arrow Destroyed: " + gameObject.name);
            }

        }
        //LogicaTextos.UpdateTextShowTime();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { counter++; }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { counter--; }
    }
}