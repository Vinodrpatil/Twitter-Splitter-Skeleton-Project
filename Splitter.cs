using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    /// <summary>
    /// Splits a single long message into a series of Tweets 
    /// </summary>
    public class Splitter
    {
        public SplitterConfiguration SplitterConfig { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Splitter"/> class.
        /// </summary>
        /// <param name="splitterConfiguration">The splitter configuration.</param>
        /// <exception cref="NotImplementedException"></exception>
        public Splitter(SplitterConfiguration splitterConfiguration)
        {
            SplitterConfig = splitterConfiguration;
        }

        /// <summary>
        /// Splits the specified message into a series of tweets.
        /// </summary>
        /// <param name="message">The message to be split.</param>
        /// <returns>A series of tweets to be posted to Twitter, in the order in which they should be posted.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<ITweet> Split(string message)
        {
            var strList = new List<Tweet>();

            int index = 0;
            var tweetMsg = string.Empty;
            var len = 0;
            while (index < message.Length)
            {
                if (message.Length - index > SplitterConfig.MaximumTweetLength)
                {
                    len = SplitterConfig.MaximumTweetLength;
                }
                else
                {
                    len = message.Length - index;
                }
                tweetMsg = message.Substring(index, len);

                strList.Add(new Tweet()
                {
                    Message = tweetMsg.Trim()
                });
                index = index + tweetMsg.Length;
            }

            return FormatTweet(strList);
        }
        public IEnumerable<ITweet> FormatTweet(List<Tweet> tweetList)
        {

            return tweetList;
        }

    }
}
