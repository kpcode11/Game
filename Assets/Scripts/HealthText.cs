using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3(0, 75, 0);
    public float timeToFade = 1f;

    RectTransform textTransform;
    private float timeElapsed = 0f;
    private Color startColor;
    TextMeshProUGUI textmeshpro;
    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
        textmeshpro = GetComponent<TextMeshProUGUI>();
        startColor = textmeshpro.color;
    }

    private void Update()
    {
        textTransform.position += moveSpeed * Time.deltaTime;
        timeElapsed += Time.deltaTime;

        if (timeElapsed < timeToFade)
        {
            float fadeAlpha = startColor.a * (1 - timeElapsed / timeToFade);
            textmeshpro.color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
        }else{
            Destroy(gameObject);
        }
    }
}
