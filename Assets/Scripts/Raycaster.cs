using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private Camera _camera;

    private readonly int _mouseButtonNumber = 0;

    public event Action<Cube> CubeClicked;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonNumber))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                if (hit.collider.TryGetComponent(out Cube cube))
                    CubeClicked(cube);
        }
    }
}
