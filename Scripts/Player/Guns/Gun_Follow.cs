using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Follow : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Obtenha a posição do mouse em relação à câmera
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calcule a direção do mouse em relação ao objeto
        Vector3 direction = mousePosition - transform.position;

        // Calcule o ângulo em radianos usando a função Atan2
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Crie um Quaternion com a rotação em torno do eixo Z
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        // Aplique a rotação gradualmente usando Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50 * Time.deltaTime);

        // Flip o sprite horizontalmente se o mouse estiver à esquerda do objeto
        if (direction.x < 0f)
        {
            spriteRenderer.flipY = true;
        }
        // Caso contrário, mantenha o sprite com o flip desativado
        else
        {
            spriteRenderer.flipY = false;
        }
    }
}
