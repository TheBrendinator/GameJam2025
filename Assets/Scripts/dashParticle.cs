using UnityEngine;
using UnityEngine.UIElements;

public class dashParticle : MonoBehaviour
{
    public Camera cam;
    private void Update()
    {
        transform.position = cam.transform.position;
        transform.rotation = cam.transform.rotation;
    }
}
