using UnityEngine;

public class FInishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //go to next level
        SceneController.instance.NextLevel();
    }
}
