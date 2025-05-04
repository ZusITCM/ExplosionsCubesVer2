using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _devideChance = 100;
    [SerializeField] private int _maximumChance = 100;
    [SerializeField] private int _minimumChance = 0;

    [SerializeField] private int _minCloneCount = 2;
    [SerializeField] private int _maxCloneCount = 6;

    [SerializeField] private Vector3 _scaleReduction = new(0.5f, 0.5f, 0.5f);

    private Rigidbody _rigidbody;

    public int DevideÑhance
    {
        get => _devideChance;
        set => _devideChance = Mathf.Clamp(value, _minimumChance, _maximumChance);
    }

    public int MaxCloneCount => _maxCloneCount;
    public int MinCloneCount => _minCloneCount;
    public int MaximumChance => _maximumChance;
    public int MinimumChance => _minimumChance;

    public Vector3 ScaleReduction => _scaleReduction;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();

        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
