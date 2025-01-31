using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Going_Medieval___Impressiveness_calc
{
	public class InterpLerpCalcs
	{
		private static float aestheticValue;
		private static float wealthValue;
		private static float spaciousnessValue;

		private static float lowerThres;
		private static float upperThres;
		private static float lowerMult;
		private static float upperMult;

		private static float finalResult;

		//aesthetic arrays
		static float[] aestValues = { -50, -30, -20, -5, 0, 10, 20, 30, 40, 50 };
		static float[] aestMult = { 0, 0.5f, 1, 3, 3.5f, 4.5f, 8, 16, 32, 65 };

		//Wealth arrays
		static float[] wealthValues = { 0, 90, 230, 500, 2000, 4000, 10000 };
		static float[] wealthMult = { 0, 2.5f, 3, 4, 8, 16, 32 };

		//Spaciousness arrays
		static float[] spacValues = { 0, 16, 30, 60, 120, 200 };
		static float[] spacMult = { 0, 3, 3.5f, 4, 7, 12 };

		TierList tierList = new TierList();

		public void FinalResultOutput()
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("Input your Aesthetics value");
				if (!float.TryParse(Console.ReadLine(), out aestheticValue)) break;

				Console.WriteLine("Input your Wealth value");
				if (!float.TryParse(Console.ReadLine(), out wealthValue)) break;

				Console.WriteLine("Input your Spaciousness value");
				if (!float.TryParse(Console.ReadLine(), out spaciousnessValue)) break;

				Console.WriteLine("Your current tier is: " + FinalResult() + " / " + tierList.TierResult(finalResult));
				Console.WriteLine();
			}
			Console.ReadKey();
		}
		private float CalcLerp(float baseValue, float[] valueArray, float[] multArray)
		{
			for (int i = 0; i <= valueArray.Length - 1; i++)
			{
				if (i == valueArray.Length - 1)
					break;

				if (baseValue >= valueArray[i] && baseValue < valueArray[i + 1])
				{
					lowerThres = valueArray[i];
					lowerMult = multArray[i];

					upperThres = valueArray[i + 1];
					upperMult = multArray[i + 1];
				}

			}

			float denominator = upperThres - lowerThres;
			if (denominator == 0) return lowerMult;

			float interpolation = (baseValue - lowerThres) / denominator;

			float lerp = lowerMult + (upperMult - lowerMult) * interpolation;

			return lerp;
		}

		private string FinalResult()
		{
			finalResult = CalcLerp(aestheticValue, aestValues, aestMult) * CalcLerp(wealthValue, wealthValues, wealthMult) * CalcLerp(spaciousnessValue, spacValues, spacMult);

			return finalResult.ToString("0.00");
		}



	}
}