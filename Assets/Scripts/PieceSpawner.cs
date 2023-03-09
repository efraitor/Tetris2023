using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    //Array donde guardaremos los objetos que serán spawneados
    public GameObject[] levelPieces;

    //Referencias para saber la pieza que tenemos y la siguiente que nos dará el juego
    public GameObject currentPiece, nextPiece;

    // Start is called before the first frame update
    void Start()
    {
        //Sacamos la siguiente pieza para tenerla visible -> Instantiate(pieza que debe aparecer, posición en la que aparece, rotación con la que aparece)
        nextPiece = Instantiate(levelPieces[0], transform.position, Quaternion.identity);
        //nextPiece = Instantiate(levelPiece[0], transform.position, transform.rotation);
        //Activo esa pieza (su script para que esta funcione)
        SpawnNextPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para spawnear piezas
    public void SpawnNextPiece()
    {
        //Al ir a spawnear la siguiente pieza, la que teníamos guardada pasa a ser la actual, por lo que activamos su script para poder moverla
        currentPiece = nextPiece;
        //Activo esa pieza (su script para que esta funcione)
        currentPiece.GetComponent<Piece>().enabled = true;

        //Para cada bloque dentro de esa pieza
        foreach(SpriteRenderer child in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            //Cogemos el color actual de ese bloque(hijo)
            Color currentColor = child.color;
            //Hacemos algo transparente a ese bloque
            currentColor.a = 1f; //La transparencia va entre 0 y 1
            child.color = currentColor;
        }

        //Llamamos a la corrutina que prepara la siguiente pieza
        StartCoroutine("PrepareNextPieceCO");
    }

    //Corrutina para preparar la siguiente pieza
    IEnumerator PrepareNextPieceCO()
    {
        //Esperamos antes de nada un tiempo
        yield return new WaitForSeconds(0.1f);

        //Tomamos un valor aleatorio comprendido en la longitud de todo el Array
        int i = Random.Range(0, levelPieces.Length); //Random.Range(valor más bajo, valor más alto)

        //Sacamos la siguiente pieza para tenerla visible -> Instantiate(pieza que debe aparecer, posición en la que aparece, rotación con la que aparece)
        nextPiece = Instantiate(levelPieces[i], transform.position, Quaternion.identity);
        //Desactivamos el Script para que la siguiente pieza no se mueva
        nextPiece.GetComponent<Piece>().enabled = false;
        //Para cada bloque dentro de esa pieza
        foreach(SpriteRenderer child in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            //Cogemos el color actual de ese bloque(hijo)
            Color currentColor = child.color;
            //Hacemos algo transparente a ese bloque
            currentColor.a = 0.3f; //La transparencia va entre 0 y 1
            child.color = currentColor;
        }
    }
}
