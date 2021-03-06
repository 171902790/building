﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Building.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual Module Superior { get; set; }

        public virtual User Creator { get; set; }

        public string Info { get; set; }

        public virtual IList<Article> Articles { get; set; }

        public virtual IList<Ad> Ads { get; set; }
    }


    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public virtual User Author { get; set; }

        public string Content { get; set; }

        public string Info { get; set; }

        public virtual Module Belong { get; set; }
    }

    public class Ad
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual User Creator { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Url { get; set; }

        public string Info { get; set; }

        public AdType AdType { get; set; }

        public virtual Module Belong { get; set; }
    }

    public enum AdType
    {
        Static,
        Mutiple
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public string Password { get; set; }

        public string Info { get; set; }
    }
}