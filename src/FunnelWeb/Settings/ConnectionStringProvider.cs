﻿using FunnelWeb.DatabaseDeployer;

namespace FunnelWeb.Settings
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IBootstrapSettings settings;
        private readonly IAppHarborSettings appHarborSettings;

        public ConnectionStringProvider(IBootstrapSettings settings, IAppHarborSettings appHarborSettings)
        {
            this.settings = settings;
            this.appHarborSettings = appHarborSettings;
        }

        public string ConnectionString
        {
            get
            {
                return appHarborSettings.SqlServerConnectionString ?? settings.Get("funnelweb.configuration.database.connection");
            }
            set
            {
                if (appHarborSettings.SqlServerConnectionString != null)
                    appHarborSettings.SqlServerConnectionString = value;
                else
                    settings.Set("funnelweb.configuration.database.connection", value);
            }
        }

        public string Schema
        {
            get
            {
                return settings.Get("funnelweb.configuration.database.schema");
            }
            set
            {
                settings.Set("funnelweb.configuration.database.schema", value);
            }
        }

        public string DatabaseProvider
        {
            get { return (settings.Get("funnelweb.configuration.database.provider") ?? "sql").ToLower(); }
            set { settings.Set("funnelweb.configuration.database.provider", value); }
        }
    }
}