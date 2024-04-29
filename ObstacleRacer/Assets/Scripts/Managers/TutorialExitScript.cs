using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialExitScript : MonoBehaviour
{
    public string player1Tag = "Player";
    public string player2Tag = "Player2";

    private bool player1InZone = false;
    private bool player2InZone = false;

    public int mediumLevelIndex = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(player1Tag))
        {
            player1InZone = true;
            Debug.Log("Player 1 in zone");
        }
        else if (other.CompareTag(player2Tag))
        {
            player2InZone = true;
            Debug.Log("Player 2 in zone");
        }

        
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(player1Tag))
        {
            player1InZone = false;
        }
        else if (other.CompareTag(player2Tag))
        {
            player2InZone = false;
        }
    }*/

    private void Update()
    {
        CheckBothPlayersInZone();
        
    }
    private void CheckBothPlayersInZone()
    {
        if (player1InZone && player2InZone)
        {
            Debug.Log("Both players in their zone");
            // Both players are in their respective zones
            // Transition to gameplay scene
            SceneManager.LoadScene(mediumLevelIndex);
        }
    }
}
