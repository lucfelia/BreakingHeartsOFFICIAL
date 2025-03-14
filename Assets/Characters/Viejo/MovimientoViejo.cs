using UnityEngine;

public class MovimientoViejo : MonoBehaviour
{
    // Variables
    private Vector3 originalPosition;
    private Vector3 targetOffset = new Vector3(+2f, -0.5f, 0f); // left movement
    public float speed = 5f;
    public MenuManager menuManager;
    private bool move = false;

    private Vector3 squeezeScale = new Vector3(1f, 0.95f, 1f); // Scale for squeezing
    private Vector3 originalScale; // Store original scale

    private float animationDuration = 0.5f; // Squeeze animation duration
    private float animationTime = 0f;
    private bool squeezing = true; // Controls squeeze loop
    private float yOffset = -0.25f; // Y-axis offset when squeezed



    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            // Move to the target offset and reset scale
            transform.position = Vector3.Lerp(transform.position, originalPosition + targetOffset, speed * Time.deltaTime);
            transform.localScale = originalScale; // Reset scale
            animationTime = 0f; // Reset animation timer
        }
        else
        {
            // Loop the squeeze animation
            animationTime += (squeezing ? 1 : -1) * Time.deltaTime / animationDuration;

            if (animationTime >= 1f)
            {
                animationTime = 1f;
                squeezing = false;
            }
            else if (animationTime <= 0f)
            {
                animationTime = 0f;
                squeezing = true;
            }

            Vector3 targetPosition = originalPosition + new Vector3(0, yOffset, 0);
            transform.localScale = Vector3.Lerp(originalScale, squeezeScale, animationTime);
            transform.position = Vector3.Lerp(originalPosition, targetPosition, animationTime);
        }

        if (menuManager.curarGameplay.activeSelf)
        {
            move = true;
        }
        else
        {
            move = false;
        }
    }
}
