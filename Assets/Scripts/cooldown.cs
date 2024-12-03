using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cooldown : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void reset_cooldown(float cooldown_time)
    {
        button.interactable = false;
        Invoke("activate_again", cooldown_time);
    }

    void activate_again()
    {
        button.interactable = true;
    }

}
