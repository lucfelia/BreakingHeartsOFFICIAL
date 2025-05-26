using UnityEngine;

public class SpriteZackChangeLvls : MonoBehaviour
{
    public Vector3 pos1lvl;
    public Vector3 pos2lvl;
    public Vector3 pos3lvl;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos1lvl;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.lvlsUnblocked == 1)
        {
            transform.position = pos1lvl;
        }
        if (GameManager.Instance.lvlsUnblocked == 2) {
            transform.position = pos2lvl;
        }
        if (GameManager.Instance.lvlsUnblocked >= 3)
        {
            transform.position = pos3lvl;
        }
    }
}
