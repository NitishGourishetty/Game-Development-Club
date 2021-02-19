using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthScript : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthHp;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = 0.5f;
        healthHp.text = "50";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
