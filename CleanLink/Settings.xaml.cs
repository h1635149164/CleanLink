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

public partial class Settings : ContentPage
{
    List<Property> filterConfig = new List<Property>();
    List<String> excludedFilters = new List<string>();

    public Settings()
    {
        InitializeComponent();

        string unloaded = Preferences.Default.Get("inactiveFilters", string.Empty);

        List<string> availableFilters = Data.available;
        List<string> unloadedFilters;
        if (unloaded != string.Empty)
        {
            unloadedFilters = unloaded.Split(';').ToList();
        }
        else
        {
            unloadedFilters = new List<string>();
        }
        excludedFilters = unloadedFilters;

        for (int index = 0; index < unloadedFilters.Count; index++)
        {
            availableFilters.Remove(unloadedFilters[index]);
        }

        for (int index = 0; index < availableFilters.Count; index++)
        {
            filterConfig.Add(new Property(availableFilters[index], true));
        }
        for (int index = 0; index < unloadedFilters.Count; index++)
        {
            filterConfig.Add(new Property(unloadedFilters[index], false));
        }

        filterConfig = filterConfig.OrderBy(x => x.Code).ToList();
        EnabledDisabled.ItemsSource = filterConfig;
        currentlySaved.Text = $"Currently saved: {Preferences.Default.Get<string>("inactiveFilters", string.Empty)}";
    }

    private void SaveState(object sender, EventArgs e)
    {
        Preferences.Default.Clear("inactiveFilters");
        Preferences.Default.Set<string>("inactiveFilters", String.Join(';', excludedFilters));

        currentlySaved.Text = $"Currently saved: {Preferences.Default.Get<string>("inactiveFilters", string.Empty)}";

    }

    private void IsOn_Toggled(object sender, ToggledEventArgs e)
    {
        Switch origin = sender as Switch;
        Property temp = (Property)origin.BindingContext;

        if (temp.Value == true)
        {
            excludedFilters.Remove(temp.Code);
        }
        else
        {
            excludedFilters.Add(temp.Code);
        }
        excludedFilters = excludedFilters.OrderBy(x => x).ToList();
    }
}