using UnityEngine;
using UnityEngine.UI;

public class FinishLineScript : MonoBehaviour
{
    public Text winText; // Reference to the UI text element to display the winner

    public Timer timer;

    private bool isGameEnded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is a player and the game hasn't ended yet
        if ((other.CompareTag("Player") || other.CompareTag("Player2")) && !isGameEnded)
        {
            // Pause the game
            Time.timeScale = 0f;

            // Determine the winning player
            string winner = other.CompareTag("Player") ? "1" : "2";

            // Display the winner text
            winText.text = "Player " + winner + " Wins with a time of " + timer.GetTimerText() + " \nPress R to rematch \nPress P to return to menu";

            // Set game ended flag to prevent further triggers
            isGameEnded = true;
        }
    }
}
