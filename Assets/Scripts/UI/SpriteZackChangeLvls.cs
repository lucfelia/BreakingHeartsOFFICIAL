using UnityEngine;

public class SpriteZackChangeLvls : MonoBehaviour
{
    public Vector3 pos1lvl = Vector3.zero;
    public Vector3 pos2lvl = Vector3.zero;
    public Vector3 pos3lvl = Vector3.zero;

    public int lvlDeDesbloqueo;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos1lvl;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.lvlsUnblocked < lvlDeDesbloqueo)
        {
            transform.position = pos1lvl;
        }
        if (GameManager.Instance.lvlsUnblocked == lvlDeDesbloqueo) {
            transform.position = pos2lvl;
        }
        if (GameManager.Instance.lvlsUnblocked > lvlDeDesbloqueo)
        {
            transform.position = pos3lvl;
        }
    }
}
