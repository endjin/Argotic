﻿using System;
using System.IO;

using Argotic.Extensions.Core;
using Argotic.Syndication;

namespace Argotic.Examples
{
    /// <summary>
    /// Contains the code examples for the <see cref="WellFormedWebCommentsSyndicationExtension"/> class.
    /// </summary>
    /// <remarks>
    ///     This class contains all of the code examples that are referenced by the <see cref="WellFormedWebCommentsSyndicationExtension"/> class. 
    ///     The code examples are imported using the unique #region identifier that matches the method or entity that the sample code describes.
    /// </remarks>
    public static class WellFormedWebCommentsSyndicationExtensionExample
    {
        /// <summary>
        /// Provides example code for the WellFormedWebCommentsSyndicationExtension class.
        /// </summary>
        public static void ClassExample()
        {
            // Framework auto-discovers supported extensions based on XML namespace attributes (xmlns) defined on root of resource
            RssFeed feed    = RssFeed.Create(new Uri("http://www.example.com/feed.aspx?format=rss"));

            // Extensible framework entities provide properties/methods to determine if entity is extended and predicate based seaching against available extensions
            if(feed.Channel.HasExtensions)
            {
                WellFormedWebCommentsSyndicationExtension channelExtension = feed.Channel.FindExtension(WellFormedWebCommentsSyndicationExtension.MatchByType) as WellFormedWebCommentsSyndicationExtension;
                if (channelExtension != null)
                {
                    // Process channel extension
                }
            }

            foreach(RssItem item in feed.Channel.Items)
            {
                if (item.HasExtensions)
                {
                    WellFormedWebCommentsSyndicationExtension itemExtension = item.FindExtension(WellFormedWebCommentsSyndicationExtension.MatchByType) as WellFormedWebCommentsSyndicationExtension;
                    if (itemExtension != null)
                    {
                        // Process extension for current item
                    }
                }
            }

            // By default the framework will automatically determine what XML namespace attributes (xmlns) to write 
            // on the root of the resource based on the extensions applied to extensible parent and child entities
            using(FileStream stream = new FileStream("Feed.xml", FileMode.Create, FileAccess.Write))
            {
                feed.Save(stream);
            }
        }
    }
}