using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class AddOrDeleteFriendData
    {
        public int FriendId { get; set; }
        public string RecipientEmail { get; set; }
    }
}
