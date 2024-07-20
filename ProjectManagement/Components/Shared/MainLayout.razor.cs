﻿using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace ProjectManagement.Components.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem>? Menus { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                new() { Text = "Home", Icon = "fa-solid fa-fw fa-home", Url = "/Home" , Match = NavLinkMatch.All},
                new() { Text = "Project", Icon = "fa-solid fa-fw fa-briefcase", Url = "/Project" },
                new() { Text = "User", Icon = "fa-solid fa-fw fa-briefcase", Url = "/User" },
                new() { Text = "Test", Icon = "fa-solid fa-fw fa-check-square", Url = "/Test" },
                new() { Text = "Counter", Icon = "fa-solid fa-fw fa-check-square", Url = "/counter" },
                new() { Text = "Weather", Icon = "fa-solid fa-fw fa-database", Url = "/weather" },
                new() { Text = "Table", Icon = "fa-solid fa-fw fa-table", Url = "/table" },
                new() { Text = "Roster", Icon = "fa-solid fa-fw fa-users", Url = "/users" }
            };

            return menus;
        }
    }
}
