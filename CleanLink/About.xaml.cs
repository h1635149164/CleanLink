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

namespace CleanLink;

public partial class About : ContentPage
{
    public About()
    {
        InitializeComponent();
        VersionLabel.Text = $"Version: {AppInfo.Current.VersionString}";
    }

    private void Github_Clicked(object sender, EventArgs e)
    {
        try
        {
            Browser.Default.OpenAsync("https://github.com/h1635149164/CleanLink");
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void License_Clicked(object sender, EventArgs e)
    {
        Browser.Default.OpenAsync("https://github.com/h1635149164/CleanLink/blob/release/LICENSE");
    }

    private void thirdPartyLicense_open(object sender, EventArgs e)
    {
        Button button = sender as Button;
        License temp = (License)button.BindingContext;

        Browser.Default.OpenAsync(temp.source);
    }
}