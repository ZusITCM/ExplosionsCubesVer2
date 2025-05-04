using System.Collections.Generic;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    public void OnCubeClick(Cube cube)
    {
        List<Rigidbody> rigidbodies = new();

        foreach(Cube tempCube in _spawner.Spawn(cube))
            if (tempCube.TryGetComponent(out Rigidbody rigidbody))
                rigidbodies.Add(rigidbody);

        if (rigidbodies.Count > 0)
            _exploder.Explode(rigidbodies);
        else
            _exploder.Explode(cube);

        cube.Destroy();
    }
}
