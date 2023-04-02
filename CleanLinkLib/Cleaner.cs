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

using CleanLink.Lib.Resources;
using System.Text.RegularExpressions;

namespace CleanLink.Lib
{
    public class Cleaner
    {
        public List<Regex> regx;

        public Cleaner(string? filtered = "")
        {
            List<string> removedFilters = filtered.Split(';').ToList();
            List<string> activeFilters = Data.available;


            for (int index = 0; index < removedFilters.Count; index++)
            {
                activeFilters.Remove(removedFilters[index]);
            }

            Dictionary<string, string> filterValues = Data.filters;

            regx = activeFilters.Select(pattern => new Regex(filterValues[pattern])).ToList();
        }

        public string Clean(string text)
        {
            if (text.Length <= 0) { return text; }

            foreach (Regex regex in regx)
            {
                text = SubClean(regex, text);
            }

            return text;
        }

        private string SubClean(Regex regex, string text)
        {
            var matches = regex.Matches(text);

            if (matches.Count <= 0)
            {
                return text;
            }

            foreach (Match match in matches)
            {
                text = text.Remove(match.Index, match.Length);
                text = text.Insert(match.Index, match.Groups["link"].Value);
            }

            return text;
        }
    }
}