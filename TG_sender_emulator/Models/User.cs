﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_sender_emulator.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Id.ToString() + " - " + Name;
        }
    }
}
