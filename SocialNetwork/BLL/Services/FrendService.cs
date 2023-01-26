using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository FriendRepository;
        UserRepository UserRepository;
        public FriendService()
        {
            FriendRepository = new FriendRepository();
            UserRepository = new UserRepository();
        }
        public void Create(Friend friend)
        {
            if (friend.frend_id == 0)
                throw new ArgumentNullException(friend.ToString());

            var friendEntity = new FriendEntity()
            {
                friend_id = friend.frend_id,
            };

            if (FriendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
        public void Delete(Friend friend)
        {
            if (friend.frend_id == 0)
                throw new ArgumentNullException(nameof(friend));
            var friendEntity = new FriendEntity()
            {
                friend_id = friend.frend_id,
            };

            FriendRepository.Delete(friend.frend_id);
        }
        public IEnumerable<Friend> GetFriends(int userId)
        {
            var friends = new List<Friend>();

            FriendRepository.FindAllByUserId(userId).ToList().ForEach(m =>
            {
                var user_id = UserRepository.FindById(m.user_id);
                var friend_id = UserRepository.FindById(m.friend_id);

                friends.Add(new Friend());
            }); 
            
            return friends;
        }
    }
}
