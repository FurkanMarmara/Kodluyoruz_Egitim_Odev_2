using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Text _healthText;




    public void SetHealthBar(float hitPoint)
    {
        _slider.value = (hitPoint/100);
        _healthText.text = hitPoint.ToString();
    }

}
