using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Pgpg.Web.Views
{
    public abstract class PgpgRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PgpgRazorPage()
        {
            LocalizationSourceName = PgpgConsts.LocalizationSourceName;
        }
    }
}
