using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube cube)
    {
        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, cube.ExplosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody) == false)
                continue;

            rigidbody.AddExplosionForce(cube.ExplosionForce, cube.transform.position, cube.ExplosionRadius);
            Instantiate(_effect, transform.position, transform.rotation);
        }
    }
}
