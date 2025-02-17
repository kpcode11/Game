// using UnityEngine;

// public class ProjectileLauncher : MonoBehaviour
// {
//     public Transform launchPoint; // Reference to the launch point
//     public GameObject projectilePrefab; // Reference to the projectile prefab
//     public void FireProjectile()
//     {
//         GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation); // Instantiate the projectile prefab at the position of the GameObject
//         Vector3 origScale = projectile.transform.localScale; // Store the original scale of the projectile

//         projectile.transform.localScale = new Vector3(origScale.x * transform.localScale.x > 0 ? 1:-1, origScale.y, origScale.z); // Set the scale of the projectile to the scale of the GameObject
//     }
// }
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint; // Reference to the launch point
    public GameObject projectilePrefab; // Reference to the projectile prefab

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation); // Instantiate the projectile prefab at the position of the GameObject

        // Set the scale of the projectile to 0.44 while preserving the direction
        float direction = transform.localScale.x > 0 ? 1 : -1;
        projectile.transform.localScale = new Vector3(0.44f * direction, 0.44f, 0.44f);
    }
}
