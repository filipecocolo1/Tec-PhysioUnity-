using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject image_Down;
    [SerializeField] private GameController gameController;


    public void OnMouseDown()//Metodo serve para clicar na imagem 
    {
        if (image_Down.activeSelf && gameController.canOpen)
        {
            image_Down.SetActive(false);
            gameController.imageOpened(this);
        }
    }
    private int _spritId;

    public int spritId
    {
        get { return _spritId; }
    }
    public void ChangeSprite(int id, Sprite Image)
    {
        _spritId = id;
        GetComponent<SpriteRenderer>().sprite = Image;
    }
    public void Close()
    {
        image_Down.SetActive(true);//Esconde a Imagem

    }

}
