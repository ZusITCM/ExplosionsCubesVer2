using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Exploder))]
public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private Exploder _exploder;

    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.CubeClicked += TryDevide;
    }

    private void OnDisable()
    {
        _raycaster.CubeClicked -= TryDevide;
    }

    public void TryDevide(Cube cube)
    {
        List<Rigidbody> rigidbodies = new();

        if (cube.IsDevide())
            rigidbodies = _spawner.Spawn(cube);
        else
            _exploder.Explode(cube);

        if (rigidbodies.Count > 0)
            _exploder.Explode(rigidbodies, cube.transform.position);

        cube.Destroy();
    }
}
