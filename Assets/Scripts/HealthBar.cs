using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public cannon cannon;
    public void UpdateHealthBar()
    {
        Debug.Log(cannon.health);
        Debug.Log(cannon.maxHealth);
        healthBarImage.fillAmount = Mathf.Clamp(cannon.health / cannon.maxHealth, 0, 1f);

    }
}
