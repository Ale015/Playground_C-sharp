using playground_c_sharp;


int[] arrTeste = new int[]{12,14,24,32, 43, 52, 67,89, 121, 143};
int[] arr = new int[]{4,1,5,2, 13, 9, 7,19, 21, 13};
List<int> lista = new List<int>() { 1, 2, 3 , 4 };


List<int> listaDesarrumada = new List<int>() { 11, 2, 15, 23, 12, 43, 51, 1, 2 , 7, 9, 12, 3 , 4 };
//var resultado = Funcoes.SomaRecursiva(lista);

//Console.WriteLine($"Resultado: {resultado}");



var resultado2 = Funcoes.QuickSort(listaDesarrumada);
Console.WriteLine(string.Join(", ", resultado2 ));




Console.ReadKey();