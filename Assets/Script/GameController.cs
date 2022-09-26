using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks.Sources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public const int columns = 4;//numero De Coluna     
    public const int rows = 2;//numero de Linha

    public const float Xspace =3f;//espaçamento entre as cartas EM X// 
    public const float Yspace = -3;//espaçamento entre as cartas EM Y// 

    [SerializeField] private MainImageScript startObJECT;
    [SerializeField] private  Sprite[] imagem;//Arry de Imagem
    
    private int[] Randomiser(int[] locations)//Metado onde vai randomisar as cartas
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


        Vector3 startPosition = startObJECT.transform.position;//Obetem a posição do primeiro Objeto na cena


        for (int i = 0; i < columns; i++)
        {

            for (int j = 0; j < rows; j++) 
            {
                MainImageScript gameImage;

                if (i == 0 && j == 0)
                {
                    gameImage = startObJECT;//Posição que inicial do primeiro objeto permanece inalterado.


                }
                else
                {
                    gameImage =Instantiate(startObJECT) as MainImageScript;// Onde proximo Objeto é criado
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
    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    private int score = 0;
    private int attempts = 0;

    [SerializeField] private Text scoreText;

    [SerializeField] private Text attempstText;


    public bool canOpen
    {
        get { return secondOpen == null; }


    }

public void imageOpened(MainImageScript startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheeckGuessd());

        }

    }
    private IEnumerator CheeckGuessd()
    {

        if (firstOpen.spritId == secondOpen.spritId)
        {
            score++;
            scoreText.text = " " + score;
           
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            firstOpen.Close();
            secondOpen.Close();


        }

        //attempts++;
        //attempstText.text = "Attempts: " + attempts;

        firstOpen = null;
        secondOpen = null;


    
    }

public void Restart()
    {
        SceneManager.LoadScene("MainScene");

    }
      


}


