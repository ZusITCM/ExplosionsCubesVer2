using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private CubeClickHandler _cubeClickHandler;

    private Camera _camera;

    private readonly int _mouseButtonNumber = 0;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonNumber))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity) == false)
                return;

            if (hit.collider.gameObject.TryGetComponent(out Cube cube))
                _cubeClickHandler.OnCubeClick(cube);
        }
    }
}
