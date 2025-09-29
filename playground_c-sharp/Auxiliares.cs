using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playground_c_sharp
{
    public class Aux
    {

        public static List<char> SelectionSort(List<char> listExterna)
        {

            List<char> list = new List<char>();

            for (int i = 0; i < listExterna.Count; i++)
            {
                if (listExterna[i] >= 'a' && listExterna[i] <= 'z')
                {
                    list.Add(listExterna[i]);
                }
            }

            for (int i = 0; i < list.Count - 1; i++)
            {

                int indiceMenor = i; // indíce do primeiro ponteiro

                for (int j = i + 1; j < list.Count; j++) // i + j -> a cada interação do maior, este loop inicia pelo próximo
                {

                    // se o próximo é menor que o atual do externo
                    if (list[j] < list[indiceMenor])
                    {
                        indiceMenor = j; // o indice do menor valor agora vira 
                    }


                }

                // ou seja, o index do loop externo atual virá o menor! e agora o próximo do array será analisado com o indice menor novamente
                char temp = list[i];
                list[i] = list[indiceMenor];
                list[indiceMenor] = temp;


            }

            //Console.WriteLine(string.Join(", ", list));
            return list;

        }


        public static int? BuscaBinariaManual(int[] arr, int item)
        {

            if ( arr == null || arr.Length < 1)
            {
                return null;
            }

            int[] array = Funcoes.SelectionSortInPlace(arr); 


            int baixo = 0;
            int alto = array.Length - 1;

            while(baixo <= alto)
            {

                int meio = (baixo + alto) / 2;

                int chute = array[meio];

                if ( chute == item)
                {
                    return meio;
                }

                if (chute > item)
                {
                    alto = meio - 1;
                } else if (chute < item)
                {
                    baixo = meio + 1;
                }
            }

            return null;

        }

        public static int[]? SelectionSort(int[] array)
        {
            if (array == null || array.Length <= 0 )
            {
                return null;
            }


            for (int i = 0; i < array.Length - 1; i++)
            {

            }

        }


        public static int[]? MergeSort(int[] array)
        {

        }

    }
}
