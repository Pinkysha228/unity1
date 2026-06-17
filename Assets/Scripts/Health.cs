using UnityEngine;
using TMPro;

public class UIHealthText : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public void UpdateHealthText(int currentHealth, int maxHealth)
    {
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}