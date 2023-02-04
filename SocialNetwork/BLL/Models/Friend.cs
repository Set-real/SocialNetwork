using System;
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
        public string friend_email { get; set; }

        public Friend(string friend_email) => this.friend_email = friend_email;



    }
}
