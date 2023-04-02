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

using Android.App;
using Android.Content;
using Android.OS;
using CleanLink.Lib;

namespace CleanLink.Platforms.Android;

[Activity(Label = "Clean Link", MainLauncher = false, Exported=true)]
[IntentFilter(new[] {Intent.ActionSend}, Categories = new[] {Intent.CategoryDefault}, DataMimeType = "text/plain")]
public class CleanLink : Activity
{
    protected override async void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var intent = Intent;

        if(intent.Action == Intent.ActionSend && intent.Type == "text/plain")
        {
            Cleaner cleaner = new Cleaner(Preferences.Default.Get<string>("inactiveFilters",""));
            var text = intent.GetStringExtra(Intent.ExtraText);
            string output = cleaner.Clean(text);

            Share.RequestAsync(new ShareTextRequest { Text = output, Title = "Clean link(s)"});
            Finish();
        }
    }
}