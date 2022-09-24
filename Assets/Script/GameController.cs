using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public const int columns = 4;
    public const int rows = 2;

    public const float Xspace = 4f;
    public const float Yspace = 5f;

    [SerializeField] private MainImageScript startObJECT;
    [SerializeField] private  Sprite[] imagem;
    
    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArry = array[i];
            int j = Random.Range(i, array.Length);

            array[i] = array[j];
            array[j] = newArry;



        }
        return array;

    }
     void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3 };
        locations = Randomiser(locations);


        Vector3 startPosition = startObJECT.transform.position;

        for (int i = 0; i < columns; i++)
        {

            for (int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;

                if (i == 0 && j == 0)
                {
                    gameImage = startObJECT;


                }
                else
                {
                    gameImage =Instantiate(startObJECT) as MainImageScript;
                }
                int index = j * columns + i;
                int id=locations[index];
                gameImage.ChangeSprite(id, imagem[id]);


                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;  
                
                gameImage.transform.position =new Vector3(positionX, positionY,startPosition.z ); 
            }
        }



     }


}
