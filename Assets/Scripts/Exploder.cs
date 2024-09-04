using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode(Cube cube)
    {
        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, cube.ExplosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody) == false)
                continue;

            rigidbody.AddExplosionForce(cube.ExplosionForce, cube.transform.position, cube.ExplosionRadius);
        }
    }
}
