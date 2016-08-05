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
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "��ҵ���"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "����Χ"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "�豸չʾ"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "��Ʒչʾ"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "���̰���"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "������Դ"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "���Ŷ�̬"},
                    new Module() {Creator = user, CreateTime = DateTime.Now, Name = "��ϵ����"}
                };

                modules.ForEach(x => context.Modules.Add(x));
            }

            base.Seed(context);
        }
    }
}
