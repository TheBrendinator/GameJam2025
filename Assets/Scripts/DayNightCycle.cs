using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 120f;
    public Gradient ambientColors;
    private float rotationSpeed;
    private Light sun;

    void Start()
    {
        rotationSpeed = 360f / dayDuration;
        sun = GetComponent<Light>();
    }

    void Update()
    {
        // Rotate the sun
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        // Adjust ambient lighting
        float timeFactor = Mathf.InverseLerp(-90, 90, transform.eulerAngles.x);
        RenderSettings.ambientLight = ambientColors.Evaluate(timeFactor);
    }
}