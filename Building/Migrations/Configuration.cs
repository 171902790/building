using System.Collections.Generic;
using Building.Models;

namespace Building.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Building.Models.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Building.Models.DB context)
        {
            if (!context.Modules.Any())
            {
                var user = new User() {Name = "zws", Password = "123", CreateTime = DateTime.Now};

                var modules = new List<Module>()
                {
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "企业简介"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "服务范围"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "设备展示"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "产品展示"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "工程案例"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "人力资源"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "新闻动态"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "联系我们"}
                };

                modules.ForEach(x => context.Modules.Add(x));
            }

            base.Seed(context);
        }
    }
}
