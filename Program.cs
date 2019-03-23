using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramingTest
{
    class Program
    {
        private static List<int> _CoinList = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("使用するコインの種類を数字の大きい順にスペース区切りで入力して下さい");
            // リストに追加
            foreach (var n in Console.ReadLine().Split(' ').Select(x => int.Parse(x)))
            {
                _CoinList.Add(n);
            }

            Console.WriteLine("金額を入力してください。");

            if (!int.TryParse(Console.ReadLine(), out int price))
            {
                Console.WriteLine("金額が不正です");
            }
            // コイン枚数
            DivPrice(price, _CoinList[0], 0);
        }

        /// <summary>
        /// 入力された価格を満たすコインの最低枚数を出力するメソッド
        /// priceをcoinで割って余りを次のpriceとして再帰する
        /// </summary>
        /// <param name="price">価格</param>
        /// <param name="coin">コインの額</param>
        /// <param name="n">繰り返した回数</param>
        /// <returns></returns>
        private static bool DivPrice(int price, int coin, int n)
        {
            int price2 = price;
            int count = 0;
            if (price / coin >= 1)
            {
                count = price / coin;
                price2 = price % coin;
            }
            else
            {
                count = 0;
                price2 = price;
            }
            if (n + 1 >= _CoinList.Count)
            {
                if (price2 > 0)
                {
                    Console.WriteLine("余り" + price2.ToString());
                }
                Print(_CoinList[n], count);
                return true;
            }

            if (DivPrice(price2, _CoinList[n + 1], n + 1))
            {
                Print(_CoinList[n], count);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 硬貨の種類ごとに何枚必要か出力
        /// </summary>
        /// <param name="coinKind">硬貨の種類</param>
        /// <param name="count">枚数</param>
        private static void Print(int coinKind, int count)
        {
            Console.WriteLine(coinKind.ToString() + "円硬貨" + count.ToString() + "枚");
        }
    }
}
