using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wichtel.Common;

namespace Wichtel.Data
{
    public class Repository : IRepository
    {
        private WichtelDb db = new WichtelDb();
        public Winner LookupWinner()
        {
            var tweets = db.Tweets.ToList();
            var index = new Random().Next(0, tweets.Count - 1);
            var tweet = tweets.ElementAt(index);
            return new Winner
            {
                Who = tweet.Who,
                What = tweet.What
            };
        }
    }
}
