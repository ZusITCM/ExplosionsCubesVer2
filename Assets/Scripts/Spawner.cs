using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube cube;

    private readonly int _chanceDevider = 2;

    public List<Cube> Spawn(Cube cube)
    {
        int cloneChance = Random.Range(cube.MinimumChance, cube.MaximumChance + 1);
        int cloneCount = Random.Range(cube.MaxCloneCount, cube.MinCloneCount + 1);

        List<Cube> cubeClones = new();

        if (cloneChance <= cube.DevideÑhance)
        {
            for (int i = 0; i < cloneCount; i++)
            {
                Cube cubeClone = Instantiate(cube);

                cubeClone.DevideÑhance /= _chanceDevider;
                cubeClone.transform.localScale = cubeClone.transform.localScale - cubeClone.ScaleReduction;

                cubeClones.Add(cubeClone);
            }
        }

        return cubeClones;
    }
}
