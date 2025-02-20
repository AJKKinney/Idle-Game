using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineAnimationController : MonoBehaviour
{
    [SerializeField] private float spinSpeed;
    private RectTransform rect;
    


    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.rotation = Quaternion.Euler(0,0,rect.rotation.eulerAngles.z + (spinSpeed * Time.deltaTime));
    }
}
