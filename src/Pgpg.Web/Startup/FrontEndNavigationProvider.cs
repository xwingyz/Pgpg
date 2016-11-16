﻿using Abp.Application.Navigation;
using Abp.Localization;
using Pgpg.Core;

namespace Pgpg.Web.Startup
{
    /// <summary>
    /// This class defines font-end web site's menu.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in the front-end web site.
    /// </summary>
    public class FrontEndNavigationProvider : NavigationProvider
    {
        public const string MenuName = "Frontend";

        public override void SetNavigation(INavigationProviderContext context)
        {
            var frontEndMenu = new MenuDefinition(MenuName, new FixedLocalizableString("Frontend menu"));
            context.Manager.Menus[MenuName] = frontEndMenu;

            frontEndMenu

                //HOME
                .AddItem(new MenuItemDefinition(
                    FrontEndPageNames.Home,
                    L("HomePage"),
                    url: ""
                    )
                )
                 .AddItem(new MenuItemDefinition(FrontEndPageNames.CreditCalculator, L("CreditCalculator"), null, "/Credit/Calculator"))
                .AddItem(new MenuItemDefinition(FrontEndPageNames.CreditCalculator, L("SocialLogin"), null, "/Account/Login"))
                .AddItem(new MenuItemDefinition(FrontEndPageNames.CreditCalculator, L("Payments"), null, "Payment"))
                //ABOUT
                .AddItem(new MenuItemDefinition(
                    FrontEndPageNames.About,
                    L("AboutUs"),
                    url: "About"
                    )

                //MULTI-LEVEL MENU (JUST FOR EXAMPLE)
                //).AddItem(new MenuItemDefinition(
                //    "MultiLevelMenu",
                //    new FixedLocalizableString("Multi level menu")
                //    ).AddItem(new MenuItemDefinition(
                //        "MultiLevelMenu.1",
                //        new FixedLocalizableString("Sub menu item 1")
                //        )
                //    ).AddItem(new MenuItemDefinition(
                //        "MultiLevelMenu.2",
                //        new FixedLocalizableString("Sub menu item 2")
                //        ).AddItem(new MenuItemDefinition(
                //            "MultiLevelMenu.2.1",
                //            new FixedLocalizableString("Sub menu item 2.1")
                //            )
                //        ).AddItem(new MenuItemDefinition(
                //            "MultiLevelMenu.2.2",
                //            new FixedLocalizableString("Sub menu item 2.2")
                //            )
                //        ).AddItem(new MenuItemDefinition(
                //            "MultiLevelMenu.2.3",
                //            new FixedLocalizableString("Sub menu item 2.3")
                //            ).AddItem(new MenuItemDefinition(
                //                "MultiLevelMenu.2.3.1",
                //                new FixedLocalizableString("ASP.NET Boilerplate"),
                //                url: "http://aspnetboilerplate.com"
                //                )
                //            ).AddItem(new MenuItemDefinition(
                //                "MultiLevelMenu.2.3.2",
                //                new FixedLocalizableString("jtable.org"),
                //                url: "http://jtable.org"
                //                )
                //            )
                //        )
                //    )
                )
               
                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PgpgConsts.LocalizationSourceName);
        }
    }
}