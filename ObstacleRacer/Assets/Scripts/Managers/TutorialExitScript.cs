using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialExitScript : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform area1;
    public Transform area2;
    public int mediumLevelIndex = 2;

    private void Update()
    {
        if (IsPlayerInArea(player1, area1) && IsPlayerInArea(player2, area2))
        {
            SceneManager.LoadScene(mediumLevelIndex);
        }
    }

    private bool IsPlayerInArea(Transform player, Transform area)
    {
        // Check if the player is within the designated area
        float distance = Vector3.Distance(player.position, area.position);
        return distance < 1.0f; // Adjust the threshold as needed
    }
}
