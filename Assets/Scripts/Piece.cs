using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento horizontal de las piezas
        //Movimiento de la ficha a la izquierda
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Llamamos al método de movimiento horizontal y le pasamos la dirección izquierda
            MovePieceHorizontally(-1);
        }
        //Movimiento de la ficha a la derecha
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Llamamos al método de movimiento horizontal y le pasamos la dirección derecha
            MovePieceHorizontally(1);
        }
    }

    //Método para el movimiento horizontal
    void MovePieceHorizontally(int direction) //con direction, le pasamos un número para saber si el movimiento es a izquierda o a derecha
    {
        //Muevo la pieza en la dirección dada
        transform.position += new Vector3(direction, 0, 0);
    }
}
