﻿using Pgpg.Core.Security;

namespace Pgpg.Application.Configuration.Host.Dto
{
    public class SecuritySettingsEditDto
    {
        public bool UseDefaultPasswordComplexitySettings { get; set; }

        public PasswordComplexitySetting PasswordComplexity { get; set; }

        public PasswordComplexitySetting DefaultPasswordComplexity { get; set; }

        public UserLockOutSettingsEditDto UserLockOut { get; set; }

        public TwoFactorLoginSettingsEditDto TwoFactorLogin { get; set; }
    }
}