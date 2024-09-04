using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField, Range(2f, 10f)] int multiplicationValue;

    private int _decriseValue = 2;
    
    public void Create(Cube prefab)
    {
        int minValueCreateRandom = 2;
        int maxValueCreateRandom = 7;
        int countCreating;

        System.Random random = new System.Random();
        countCreating = random.Next(minValueCreateRandom, maxValueCreateRandom);

        for (int i = 0; i < countCreating; i++)
        {
            Vector3 position = transform.position;
            Cube newCube = Instantiate(prefab, position, Quaternion.identity);

            var color = Random.ColorHSV();
            var chanceDivide = newCube.ChanceDivision / _decriseValue;
            var scale = transform.localScale / _decriseValue;

            float force = newCube.ExplosionForce * multiplicationValue;
            float radius = newCube.ExplosionRadius * multiplicationValue;

            newCube.Initialisation(color, chanceDivide, scale, force, radius);
        }
    }
}
