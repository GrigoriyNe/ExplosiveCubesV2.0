using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] Cube _prefab;

    private Spawn _spawn;
    private Exploder _exploder;
    private float _explosionForce = 100;
    private float _explosionRadius = 20;
    private int _chanceDivision = 100;

    public int ChanceDivision => _chanceDivision;
    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;

    public void Initialisation(Color color, int chanceDivide, Vector3 scale, float force, float radius)
    {
        _meshRenderer.material.color = color;
        _chanceDivision = chanceDivide;
        transform.localScale = scale;
        _explosionForce = force;
        _explosionRadius = radius;
    }

    private void Awake()
    {
        _spawn = GetComponent<Spawn>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnMouseDown()
    {
        if (CanDivide())
            _spawn.Create(_prefab);

        else
            _exploder.Explode(_prefab);

        Destroy(gameObject);
    }

    private bool CanDivide()
    {
        System.Random random = new System.Random();
        int randomValue = random.Next(0, 100);

        return randomValue < _chanceDivision;
    }
}
