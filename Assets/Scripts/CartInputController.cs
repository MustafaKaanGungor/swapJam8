using UnityEngine;

public class CartInputController : MonoBehaviour
{

    noelFatherController NoelFatherController;


    private void Awake()
    {
        NoelFatherController = GetComponent<noelFatherController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        NoelFatherController.SetInputVector(inputVector);
    }
}
