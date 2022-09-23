using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject image_Down;

    // Start is called before the first frame update
  
    
        



    public void OnMouseDown()
    {
        if (image_Down.activeSelf)
        {
         image_Down.SetActive(false);
        }
    }
    private int _spritId;
    
    public int spritId
    {
        get { return _spritId; }
        
       
    }
    public void ChangeSprite(int id,Sprite Image)
    {
        _spritId = id;
        GetComponent<SpriteRenderer>().sprite = Image;


    }
}
