using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _devideChance = 100;
    [SerializeField] private int _minimumChance = 0;
    [SerializeField] private int _maximumChance = 100;
    [SerializeField] private int _devider = 2;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();

        SetRigidbodyParametrs(GetComponent<Rigidbody>());
    }

    public bool IsDevide() => _devideChance >= Random.Range(_minimumChance, _maximumChance + 1);

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Init()
    {
        transform.localScale = SetScale(transform.localScale);
        _devideChance = SetDevideChance(_devideChance);
    }

    private int SetDevideChance(int chance) => chance /= _devider;

    private Vector3 SetScale(Vector3 scale) => scale /= _devider;

    private void SetRigidbodyParametrs(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
        _rigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
}
