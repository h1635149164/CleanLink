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

namespace CleanLink.Lib.Resources
{
    public class Data
    {
        internal static List<string> Filters = new string[]
        {
            @"(?<link>(https://)?(www\.)?instagram\.com\/(p|(reel)|)\/[a-zA-Z0-9-_]+)((\?|/)+[a-zA-Z=0-9._f-]*)",
            @"(?<link>(https://)?(www\.)?instagram\.com\/stories\/[a-zA-Z0-9-._]+\/\d+)((\?|/)+[a-zA-Z=0-9._f-]*)?",
            @"(?<link>(https://)?(www\.)?twitter\.com/[a-zA-Z_0-9]{4,15}/status/\d+)(\?[a-zA-Z=0-9&_-]*)",
            @"(?<link>(https://)?(www\.)?reddit.com/r/[a-zA-Z_0-9-+]+/comments/[0-9a-zA-Z]+/[a-zA-Z_0-9-+]+)(/\?[a-zA-Z_0-9-+=&]+)?"
        }.ToList();
        public static List<string> available = new string[] {
            "instagram-stories",
            "instagram-posts&reels",
            "twitter-tweets",
            "reddit-posts"
        }.ToList();
        internal static Dictionary<string, string> filters = new Dictionary<string, string>
        {
            {"instagram-stories",@"(?<link>(https://)?(www\.)?instagram\.com\/stories\/[a-zA-Z0-9-._]+\/\d+)((\?|/)+[a-zA-Z=0-9._f-]*)?"},
            {"instagram-posts&reels",@"(?<link>(https://)?(www\.)?instagram\.com\/(p|(reel)|)\/[a-zA-Z0-9-_]+)((\?|/)+[a-zA-Z=0-9._f-]*)"},
            {"twitter-tweets",@"(?<link>(https://)?(www\.)?twitter\.com/[a-zA-Z_0-9]{4,15}/status/\d+)(\?[a-zA-Z=0-9&_-]*)" },
            {"reddit-posts",@"(?<link>(https://)?(www\.)?reddit.com/[ru]/[a-zA-Z_0-9-+]+/comments/[0-9a-zA-Z]+/[a-zA-Z_0-9-+]+)(/\?[a-zA-Z_0-9-+=&]+)?" }
        };
    }
    public class Property
    {
        public string Code { get; set; }
        public bool Value { get; set; }

        public Property(string _code, bool _value)
        {
            this.Code = _code;
            this.Value = _value;
        }
    }
    public class License
    {
        public string Name { get; set; }
        public string Holder { get; set; }
        public string source { get; set; }
    }
}
