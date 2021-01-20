using JETech.JEDayCare.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.JEDayCare.Core
{
    public class App
    {
        public static DbContext CurrentDbContext { get; set; }
    }
}
