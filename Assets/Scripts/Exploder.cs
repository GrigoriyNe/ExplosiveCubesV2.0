using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube cube)
    {
        int multiplicator = 5;
        float radius = cube.ExplosionRadius / cube.transform.localScale.x * multiplicator;
        float force = cube.ExplosionForce / cube.transform.localScale.x * multiplicator;

        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody) == false)
                continue;

            rigidbody.AddExplosionForce(force, cube.transform.position, radius);
            Instantiate(_effect, transform.position, transform.rotation);
        }
    }
}
