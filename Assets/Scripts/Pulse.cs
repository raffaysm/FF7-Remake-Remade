using UnityEngine;
using UnityEngine.UI;

public class Pulse : MonoBehaviour
{
    private Image glowImage;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1.0f;
    public float pulseSpeed = 2.0f;

    float alpha = 0.3f;
    bool goingUp = true;

    void Start()
    {
        glowImage = GetComponent<Image>();
    }

    void Update()
    {
        // if we're going up, increase alpha. if going down, decrease it.
        if (goingUp)
        {
            alpha += pulseSpeed * Time.deltaTime;
        }
        else
        {
            alpha -= pulseSpeed * Time.deltaTime;
        }

        // if we hit the top, start going down. if we hit the bottom, start going up.
        if (alpha >= maxAlpha)
        {
            goingUp = false;
        }
        if (alpha <= minAlpha)
        {
            goingUp = true;
        }

        // apply the alpha to the image
        Color c = glowImage.color;
        c.a = alpha;
        glowImage.color = c;
    }
}