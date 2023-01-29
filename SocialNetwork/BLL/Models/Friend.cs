﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int frend_id { get; set; }

        public Friend(int id, int user_id, int frend_id)
        {
            this.id = id;
            this.user_id = user_id;
            this.frend_id = frend_id;
        }
    }
}
