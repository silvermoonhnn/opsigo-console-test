using System;
using System.Collections.Generic;
using System.Linq;

namespace OPSIGO.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string pesan = "maafAkuenggak";
            Console.WriteLine(pesan_rahasia(pesan));

            int input = 4;
            susunan_angka(input);
        }

        static string pesan_rahasia(string pesan)
        {
            int K = Convert.ToInt32(Math.Ceiling(Math.Sqrt(pesan.Length)));
            int M = Convert.ToInt32(Math.Pow(K, 2));
            
            pesan = pesan.PadRight(M, '*');

            var arrayInput = new string [K,K];
            var arrayRotate = new string [K, K];
            
            var counter = pesan.Length;
            var text = new List<string>();
            
            for (int i = 0; i < K; i++)
			{
				for (int j = 0; j < K; j++)
				{
					arrayInput[i, j] = pesan[pesan.Length - counter].ToString();
					counter--;
				}
			}

			for (int i = (K - 1); i >= 0; i--)
			{
				for (int j = 0; j < K; j++)
				{
					arrayRotate[j, i] = arrayInput[(K - 1 - i), j];
				}
			}
            
            foreach (var item in arrayRotate)
            {
                var rahasia = item.Select(x => x.ToString()).ToList();
                text.Add(string.Join("", rahasia));
            }
            var result = string.Join("", text.Select(x => x.Replace("*", "")));
            return result;
        }

        static void susunan_angka(int input)
        {
            int []arr = new int [input];

            cari_kombinasi(arr, 0, input, input);
        }

        static void cari_kombinasi(int[] arr, int index, int n, int reducedNum)
        {
            if (reducedNum < 0) return;
        
            if (reducedNum == 0)
            {
                for (int i = 0; i < index; i++)
                    Console.Write (arr[i] + ", ");
                    Console.WriteLine();
                return;
            }
        
            int prev = (index == 0) ? 1 : arr[index - 1];
    
            for (int k = prev; k <= n ; k++)
            {
                arr[index] = k;
                cari_kombinasi(arr, index + 1, n, reducedNum - k);
            }
        }
    }
}
