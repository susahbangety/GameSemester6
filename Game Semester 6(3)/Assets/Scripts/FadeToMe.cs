using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FadeToMe : MonoBehaviour
{
    void Start()
    {
        FadeObstructionsManager.Instance.RegisterShouldBeVisible(this.gameObject);
    }
}
