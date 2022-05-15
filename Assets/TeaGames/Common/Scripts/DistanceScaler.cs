using UnityEngine;

public class DistanceScaler : MonoBehaviour
{
    [SerializeField]
    private float _initScale = 1.05f;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        float dist = Vector3.Distance(transform.position, _camera.transform.position);

        //for (int i = 0; i < 4; i++)
        //    dist = Mathf.Sqrt(dist);

        //float scale = Mathf.Max(_initScale * dist, _initScale);

        float scale = 2 * Mathf.Atan(transform.localScale.x) / 2 * dist;

        transform.localScale = new Vector3(scale, scale, 0);  
    }
}
