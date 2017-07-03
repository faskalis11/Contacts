using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApplication.Models
{
    public class Car
    {
        private string Name
        {
            set; get;
        }

        public int speed = 0;

        public void increaseSpeed()
        {
            speed += 10;
        }

    }
}