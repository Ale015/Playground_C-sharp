using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace playground_c_sharp
{
    public class Funcoes
    {
        public static char LetraMaisFrequente(string texto)
        {

            string textoFormatado = texto.ToLower().Trim();

            int[] alfabeto = new int[26];


            for (int i = 0; i < textoFormatado.Length; i++)
            {
                char c = textoFormatado[i];

                if (c >= 'a' && c <= 'z')
                {

                    alfabeto[c - 'a']++;
                }
            }


            int indiceMaior = 0;


            for (int j = 0; j < alfabeto.Length; j++)
            {
                if (alfabeto[j] > alfabeto[indiceMaior])
                {
                    indiceMaior = j;
                }
            }

            return (char)(indiceMaior + 'a');

            
        }

        public static bool EhPalindromoSimples(string texto)
        {
            string textoFormatado = texto.ToLower().Trim();

            for (int i = 0; i < textoFormatado.Length / 2; i++)
            {
                int j = textoFormatado.Length - i - 1;

                if (textoFormatado[i] == textoFormatado[j])
                {
                    continue;
                } else 
                {
                    return false;
                }


            }
            
            return true;

        }

        public static bool EhPalindromoEstendido(string txt)
        {

            txt = txt.Trim().ToLower();
            List<char> filtrado = new List<char>();

            for (int i = 0; i < txt.Length; i++)
            {
                char c = txt[i];

                if (c >= 'a' && c <= 'z')
                {
                    filtrado.Add(c);
                }
            }


            for (int i = 0; i < filtrado.Count / 2; i++)
            {
                int j = filtrado.Count - 1 - i;

                if (filtrado[i] != filtrado[j])
                {
                    return false;
                }
            }

            return true;

        }

        public static string MaxFrequenciaPalavra(string txt)
        {

            txt = txt.ToLower().Trim();
 

            List<char> listaChar = new List<char>();

            // sanitização manual
            for (int i = 0; i < txt.Length; i++)
            {
                char c = txt[i];

                if (c == ' ' || c >= 'a' && c <= 'z')
                {
                    listaChar.Add(c);
                }
            }

            string textoSanitizado = string.Join("", listaChar); // ou ToString()
            string[] arrTexto = textoSanitizado.Split(' ', StringSplitOptions.RemoveEmptyEntries); // se usar Lista, use ToList() ao final

            // poderia converter direto pra array com o listaChar.ToArray();

            Dictionary<string, int> contagem = new Dictionary<string, int>();

            // agregação aos dicionários
            for (int i = 0; i < arrTexto.Length; i++)
            {
                if (contagem.ContainsKey(arrTexto[i]))
                {
                    contagem[arrTexto[i]]++;
                } else
                {
                    contagem.Add(arrTexto[i], 1);
                }
            }

            int valorMax = 0;
            string palavraMax = "";

            foreach (KeyValuePair<string, int> item in contagem)
            {
                if (item.Value > valorMax)
                {
                    valorMax = item.Value;
                    palavraMax = item.Key.ToString(); // Redundância por segurança
                }
            }


            return palavraMax;

        }

        public static bool SaoAnagramas(string s1, string s2)
        {
            //sanitização

            s1 = s1.ToLower();
            s2 = s2.ToLower();

            List<char> s1Char = new List<char>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] >= 'a' && s1[i] <= 'z')
                {
                    s1Char.Add(s1[i]);
                }
            }

            List<char> s2Char = new List<char>();

            for (int i = 0; i < s2.Length; i++)
            {
                if (s2[i] >= 'a' && s2[i] <= 'z')
                {
                    s2Char.Add(s2[i]);
                }
            }

            // verificação comparativa de tamanho, cortando processamento caso já não sejam anagramas por tamanho
            if (s1Char.Count != s2Char.Count)
            {
                return false;
            }


            // Ordenação (Selection Sort)
            List<char> s1Sorted = Aux.SelectionSort(s1Char);
            List<char> s2Sorted = Aux.SelectionSort(s2Char);

            string s1Text = string.Join("", s1Sorted);
            string s2Text = string.Join("", s2Sorted);

            
            return s1Text == s2Text;
        }

        public static bool AnagramasOtimizado(string c1, string c2)
        {
            // sanitização
            c1 = c1.ToLower().Trim();
            c2 = c2.ToLower().Trim();
            
            Dictionary<char, int> frase1 = new Dictionary<char, int>();
            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] >= 'a' && c1[i] <= 'z')
                { 
                    if (frase1.ContainsKey(c1[i]))
                    {
                        frase1[c1[i]]++;
                    } else
                    {
                        frase1.Add(c1[i], 1);
                    }
                }
            }

            Dictionary<char, int> frase2 = new Dictionary<char, int>();
            for (int j = 0; j < c2.Length; j++)
            {
                if (c2[j] >= 'a' && c2[j] <= 'z')
                {
                    if (frase2.ContainsKey(c2[j]))
                    {
                        frase2[c2[j]]++;
                    }
                    else
                    {
                        frase2.Add(c2[j], 1);
                    }
                }
            }

            if (frase1.Count != frase2.Count)
            {
                return false;
            }


            foreach (var letra in frase1)
            {
                if (!frase2.ContainsKey(letra.Key) || frase2[letra.Key] != letra.Value)
                {
                    return false;
                }
            }


            return true;


        }

        public static int? PesquisaBinaria(int[] arr, int item)
        {   
            if (arr == null)
            {
                return null;
            }

            int[]? arrSorted = Funcoes.SelectionSortInPlace(arr);


            int indiceBaixo = 0;
            int indiceAlto = arrSorted.Length - 1;


            while (indiceBaixo <= indiceAlto)
            {


                int indiceMeio = (indiceBaixo + indiceAlto) / 2 ;

                int chute = arrSorted[indiceMeio];

                if (chute == item)
                {
                    return indiceMeio;
                }

                if (chute > item)
                {
                    indiceAlto = indiceMeio - 1;
                } else {

                    indiceBaixo = indiceMeio + 1;
                }
            }


            return null;

        }
        
        public static int[]? SelectionSortInPlace(int[] arr)
        {
            if (arr.Length == 0)
            {
                return null;
            }

            int num = arr.Length; // 10

            // loop maior 1
            for (int i = 0; i < num - 1; i++)
            {

                int indiceDoMenor = i; // 0 -> 1


                for (int j = i + 1; j < num; j++)
                {

                    if (arr[j] < arr[indiceDoMenor])
                    {
                        indiceDoMenor = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[indiceDoMenor];
                arr[indiceDoMenor] = temp;


            }

            //Console.WriteLine(string.Join(" ", arr));
            return arr;
        }

        public static int? Fatorial(int fat)
        {
            if (fat == 1)
            {
                return 1;
            }
            else
            {
                return fat * Fatorial(fat - 1);
            }
        }

        public static int? SomaRecursiva(List<int> list)
        {
            if (list.Count == 0)
            {
                return null;
            }

            if (list.Count == 1)
            {
                return list[0];
            }

            int num = list[0];

            list.RemoveAt(0);

            List<int> listReduzida = list; 

            return num + SomaRecursiva(listReduzida);

        }   
        
        public static List<int>? QuickSort(List<int> lista)
        {

            if (lista.Count < 2)
            {
                return lista;
            }

            int pivo = lista[0];

            List<int> menores = new List<int>();
            List<int> maiores = new List<int>();

            for (int i = 1; i < lista.Count; i++)
            {
                if (lista[i] <= pivo)
                {
                    menores.Add(lista[i]);
                } else
                {
                    maiores.Add(lista[i]);
                } 
            }

            List<int> menoresQuicked = QuickSort(menores);
            List<int> maioresQuicked = QuickSort(maiores);

            List<int> resultado = new List<int>();

            resultado.AddRange(menoresQuicked);
            resultado.Add(pivo);
            resultado.AddRange(maioresQuicked);

            return resultado;

        }
        
        public class HashMap<K, V>
        {
            private int Size = 30;
            private List<KeyValuePair<K, V>>[] buckets;

            private int paresSalvos = 0;

            public HashMap(int? size = null)
            {
                if (size != null)
                {
                    Size = (int)size;
                }

                buckets = new List<KeyValuePair<K, V>>[Size];

                for (int i = 0; i < Size; i++)
                {
                    buckets[i] = new List<KeyValuePair<K, V>>();
                }
            }

            // Função HashCode corrigida
            private int GenerateHashCode(K key)
            {
                if (key == null)
                {
                    return 0;
                }

                int hash = 0;

                if (key is string keyStr)
                {
                    if (string.IsNullOrEmpty(keyStr))
                    {
                        hash = 0;
                    }
                    else
                    {
                        int peso = keyStr.Length;
                        int peso1 = keyStr[0];
                        int peso2 = keyStr.Length > 1 ? keyStr[1] : keyStr[0]; // Evita IndexOutOfRange
                        
                        hash = Math.Abs(peso * peso1 * peso2); // Math.Abs para evitar índices negativos
                    }
                }
                else if (key is int keyInt)
                {
                    hash = Math.Abs((keyInt * 31415) / 2);
                }
                else
                {
                    hash = Math.Abs(key.GetHashCode());
                }

                return hash;
            }

            // Buscar índice
            private int GetIndex(K key)
            {
                int hashCode = GenerateHashCode(key);

                return hashCode % buckets.Length;


            }


            private void Redimensionamento()
            {
                int arraySize = buckets.Length;

                double fatorCarga = (double)paresSalvos / arraySize;

                if (fatorCarga > 1.8)
                {
                    
                    List<KeyValuePair<K,V>> todosElementos = new List<KeyValuePair<K,V>>();


                    foreach (var bucket in buckets)
                    {
                        foreach(var pair in bucket)
                        {
                            todosElementos.Add(pair);
                        }
                    }


                    int novoTamanhoBuckets = arraySize * 2;

                    buckets = new List<KeyValuePair<K, V>>[novoTamanhoBuckets];

                    for (int i = 0; i < novoTamanhoBuckets; i++)
                    {
                        buckets[i] = new List<KeyValuePair<K, V>>();
                    }

                    paresSalvos = 0;


                    foreach (var elemento in todosElementos)
                    {
                        PutInterno(elemento.Key, elemento.Value);
                    }


                }


            }


            private void PutInterno(K key, V value)
            {
                int index = GetIndex(key);
                var bucket = buckets[index];

                for(int i = 0; i < bucket.Count; i++)
                {
                    if (EqualityComparer<K>.Default.Equals(bucket[i].Key, key))
                    {
                        bucket[i] = new KeyValuePair<K, V>(key, value);
                        return;
                    }
                }

                bucket.Add(new KeyValuePair<K, V>(key, value));
                paresSalvos++;
                return;

            }



            // Método Put para adicionar/atualizar elementos
            public void Put(K key, V value)
            {

                Redimensionamento();

                int index = GetIndex(key);
                var bucket = buckets[index];

                // Verifica se a chave já existe e atualiza
                for (int i = 0; i < bucket.Count; i++)
                {
                    if (EqualityComparer<K>.Default.Equals(bucket[i].Key, key))
                    {
                        bucket[i] = new KeyValuePair<K, V>(key, value);
                        return;
                    }
                }

                // Se não existe, adiciona novo
                bucket.Add(new KeyValuePair<K, V>(key, value));
                paresSalvos++;
            }

            // Método Get
            public V? Get(K key)
            {
                int index = GetIndex(key);
                var bucket = buckets[index];

                foreach (var pair in bucket)
                {
                    if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                    {
                        return pair.Value;
                    }
                }

                return default(V); // Retorna valor padrão se não encontrar
            }

            // Método para verificar se contém a chave
            public bool ContainsKey(K key)
            {
                int index = GetIndex(key);
                var bucket = buckets[index];

                foreach (var pair in bucket)
                {
                    if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                    {
                        return true;
                    }
                }

                return false;
            }

            // Método para remover elemento
            public bool Remove(K key)
            {
                int index = GetIndex(key);
                var bucket = buckets[index];

                for (int i = 0; i < bucket.Count; i++)
                {
                    if (EqualityComparer<K>.Default.Equals(bucket[i].Key, key))
                    {
                        bucket.RemoveAt(i);
                        paresSalvos--;
                        return true;
                    }
                }

                return false;
            }

            // Propriedade para obter número total de elementos
            public int Count
            {
                get
                {
                    int count = 0;
                    foreach (var bucket in buckets)
                    {
                        count += bucket.Count;
                    }
                    return count;
                }
            }
        }
    }
}
