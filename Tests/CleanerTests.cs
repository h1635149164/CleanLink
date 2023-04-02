/*
    CleanLink removes tracking tokens from links that are supplied to it.
    Copyright (C) 2023  Lukáš Havel

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
*/

namespace Backend
{
    [TestClass]
    public class CleanerTest
    {
        [TestClass]
        public class Initialization
        {
            public Cleaner cleaner = new Cleaner();

            [TestMethod]
            public void IsNotNull()
            {
                Cleaner _cleaner = new Cleaner();
                Assert.IsNotNull(_cleaner);
            }
            [TestMethod]
            public void HasFilters()
            {
                int count = cleaner.regx.Count;
                Assert.IsTrue(count > 0);
            }
            [TestMethod]
            public void CorrectFilters()
            {
                string removedFilters = "instagram-stories;twitter-tweets";
                int availableFilters = Data.available.Count;

                int correctCount = availableFilters - removedFilters.Split(';').Length;

                Cleaner cleaner = new Cleaner(removedFilters);

                Assert.IsTrue(cleaner.regx.Count == correctCount);
            }
        }
        [TestClass]
        public class Functionality
        {
            public static Cleaner cleaner = new Cleaner();


            [TestClass]
            public class Platforms
            {
                [TestMethod]
                public void Instagram()
                {
                    string url1 = @"https://www.instagram.com/p/Cprds-uuia9/?utm_source=ig_web_copy_link";
                    string desired1 = @"https://www.instagram.com/p/Cprds-uuia9";

                    string url2 = @"instagram.com/p/CpqlR-gIaSI/?igshid=YmMyMTA2M2Y=";
                    string desired2 = @"instagram.com/p/CpqlR-gIaSI";

                    string url3 = @"https://www.instagram.com/reel/CnLPMynun9i/?igshid=YmMyMTA2M2Y=";
                    string desired3 = @"https://www.instagram.com/reel/CnLPMynun9i";

                    string result1 = cleaner.Clean(url1);
                    string result2 = cleaner.Clean(url2);
                    string result3 = cleaner.Clean(url3);

                    Assert.IsTrue(result1 == desired1 && result2 == desired2 && result3 == desired3);
                }
                [TestMethod]
                public void Twitter()
                {
                    string url1 = @"https://twitter.com/official_pixy/status/1634951618998444034?s=20";
                    string desired1 = @"https://twitter.com/official_pixy/status/1634951618998444034";

                    string url2 = @"https://twitter.com/COZYxBEAR/status/1634548949997727744?t=jXArSZMxym3U99HYjQykVg&s=19";
                    string desired2 = @"https://twitter.com/COZYxBEAR/status/1634548949997727744";

                    string result1 = cleaner.Clean(url1);
                    string result2 = cleaner.Clean(url2);

                    Assert.IsTrue(result1 == desired1 && result2 == desired2);
                }
            }
        }
    }
}