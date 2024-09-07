using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace ProjectManagement.Components.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        private bool UseTabSet { get; set; } = false;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = false;

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
                new() { Text = "Tasks", Icon = "fa-solid fa-fw fa-tasks", Url = "/Task" },
                new() { Text = "Progress Report", Icon = "fa-solid fa-fw fa-chart-line", Url = "/TaskReport" },
                new() { Text = "Project", Icon = "fa-solid fa-fw fa-project-diagram", Url = "/Project" },
                new() { Text = "Team Progress Report", Icon = "fa-solid fa-chart-area", Url = "/TeamReport" },
                new() { Text = "Users", Icon = "fa-solid fa-fw fa-users-cog", Url = "/User" },
                new() { Text = "Task Detail", Icon = "fa-solid fa-fw fa-magnifying-glass", Url = "/TaskDetail" },


                new() { Text = "Test", Icon = "fa-solid fa-vial", Url = "/Test" },
                new() { Text = "Counter", Icon = "fa-solid fa-calculator", Url = "/counter" },
                new() { Text = "Weather", Icon = "fa-solid fa-cloud-sun", Url = "/weather" },
                new() { Text = "Table", Icon = "fa-solid fa-table", Url = "/table" },
                new() { Text = "Roster", Icon = "fa-solid fa-users", Url = "/users" }
            };

            return menus;
        }
        private static List<MenuItem> GetIconSideMenuItems(string displayAccount)
        {
            var menus = new List<MenuItem>
            {
                new() { Text = "Home", Icon = "fa-solid fa-fw fa-home", Url = "/Home", Match = NavLinkMatch.All },
                new() { Text = "Tasks", Icon = "fa-solid fa-fw fa-tasks", Url = "/Task" },
                new() { Text = "Progress Report", Icon = "fa-solid fa-fw fa-chart-line", Url = "/PersonalReport" },
            };

            if (displayAccount == "Super Admin")
            {
                menus.AddRange(new List<MenuItem>
                {
                    new() { Text = "Project", Icon = "fa-solid fa-fw fa-project-diagram", Url = "/Project" },
                    new() { Text = "Team Progress Report", Icon = "fa-solid fa-chart-area", Url = "/TeamReport" },
                    new() { Text = "Users", Icon = "fa-solid fa-fw fa-users-cog", Url = "/User" },
                    new() { Text = "Task Detail", Icon = "fa-solid fa-fw fa-magnifying-glass", Url = "/TaskDetail" }

                    //new() { Text = "Test", Icon = "fa-solid fa-vial", Url = "/Test" },
                    //new() { Text = "Counter", Icon = "fa-solid fa-calculator", Url = "/counter" },
                    //new() { Text = "Weather", Icon = "fa-solid fa-cloud-sun", Url = "/weather" },
                    //new() { Text = "Table", Icon = "fa-solid fa-table", Url = "/table" },
                    //new() { Text = "Roster", Icon = "fa-solid fa-users", Url = "/users" }
                });
            }
            if (displayAccount == "Superviser")
            {
                menus.AddRange(new List<MenuItem>
                {
                    new() { Text = "Project", Icon = "fa-solid fa-fw fa-project-diagram", Url = "/Project" },
                    new() { Text = "Team Progress Report", Icon = "fa-solid fa-chart-area", Url = "/TeamReport" }
                });
            }
            if (displayAccount == "Admin")
            {
                menus.AddRange(new List<MenuItem>
                {
                    new() { Text = "User", Icon = "fa-solid fa-fw fa-users-cog", Url = "/User" },
                    new() { Text = "Task Detail", Icon = "fa-solid fa-fw fa-magnifying-glass", Url = "/TaskDetail" },

                });
            }
            if (displayAccount == "User")
            {
                //menus.AddRange(new List<MenuItem>
                //{
                //    new() { Text = "Project", Icon = "fa-solid fa-fw fa-briefcase", Url = "/Project" },
                //    new() { Text = "User", Icon = "fa-solid fa-fw fa-briefcase", Url = "/User" }
                //});
            }
            return menus;
        }

    }
}
