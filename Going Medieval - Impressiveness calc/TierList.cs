using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Going_Medieval___Impressiveness_calc
{
	internal class TierList
	{
		private Dictionary<string, int> tierList = new Dictionary<string, int>
		{
			{"Awful", 0},
			{"Unispiring", 10 },
			{"Modest", 15 },
			{ "Good", 65 },
			{"Superior", 300 },
			{"Luxurious", 750 },
			{"Opulent", 2500 },
			{"Palatial", 6000 }
		};

		public string TierResult(float finalResult)
		{
			foreach (var tier in tierList.OrderByDescending(x => x.Value))
			{
				if (finalResult >= tier.Value)
				{
					return tier.Key;
				}
			}
			return null;
		}
	}
}