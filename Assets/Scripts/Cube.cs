using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Exploder))]

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private Spawner _spawner;
    private Exploder _exploder;
    private float _explosionForce = 20;
    private float _explosionRadius = 20;
    private int _chanceDivision = 100;

    public int ChanceDivision => _chanceDivision;
    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;

    private void Start()
    {
        Init(Random.ColorHSV(), _chanceDivision, transform.localScale);
    }

    private void OnMouseDown()
    {
        if (CanDivide())
            _spawner.Create(this);

        else
            _exploder.Explode(this);

        Destroy(gameObject);
    }

    public void Init(Color color, int chanceDivide, Vector3 scale)
    {
        _spawner = GetComponent<Spawner>();
        _exploder = GetComponent<Exploder>();

        _meshRenderer.material.color = color;
        _chanceDivision = chanceDivide;
        transform.localScale = scale;
    }

    private bool CanDivide()
    {
        System.Random random = new System.Random();
        int maxValueRandom = 100;
        int randomValue = random.Next(0, maxValueRandom);

        return randomValue <= _chanceDivision;
    }
}
