﻿using Abp.Application.Navigation;

namespace Pgpg.Web.Views.Shared.Components.TopMenu
{
    public class TopMenuViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}