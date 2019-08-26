
using UnityEngine;

public class EndLevel1 : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerEnter ()
    {
        gameManager.CompleteLevel();
    }
}
