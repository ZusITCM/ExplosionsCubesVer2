using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube cube;

    [SerializeField] private int _minCloneCount = 2;
    [SerializeField] private int _maxCloneCount = 6;

    private readonly int _chanceDevider = 2;

    public List<Rigidbody> Spawn(Cube cube)
    {
        int cloneCount = Random.Range(_minCloneCount, _maxCloneCount + 1);

        List<Rigidbody> cubeClones = new();

        if (cube.IsDevide())
        {
            for (int i = 0; i < cloneCount; i++)
            {
                Cube cubeClone = Instantiate(cube);

                cubeClone.DevideChance /= _chanceDevider;
                cubeClone.transform.localScale = cubeClone.transform.localScale - cubeClone.ScaleReduction;

                cubeClones.Add(cubeClone.GetComponent<Rigidbody>());
            }
        }

        return cubeClones;
    }
}
