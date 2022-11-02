namespace LeetCode
{
    public static class BestTimeToBuyAndSellStock
    {
        public static void Test()
        {
            Console.WriteLine(MaxProfit(new int[] {7, 1, 5, 3, 6, 4 }));
        }

        private static int MaxProfit(int[] prices)
        {
            int min = prices[0];
            int profit = 0;

            for(int i = 1; i < prices.Length; i++)
            {
                if(prices[i] - min > profit) 
                {
                    profit = prices[i] - min;
                }
                if (prices[i] < min)
                {
                    min = prices[i];
                }
            }

            return profit;
        }
    }
}
