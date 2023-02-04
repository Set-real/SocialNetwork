using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userRepository= new UserRepository();
            friendRepository= new FriendRepository();
        }

        public void AddFriend(string email)
        {
            Friend friend = new Friend(email);

            if (String.IsNullOrEmpty(friend.friend_email))
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(friend.friend_email))
                throw new ArgumentNullException();
            var findFrendEntity = this.userRepository.FindByEmail(friend.friend_email);
            if (findFrendEntity is null)
                throw new UserNotFoundException();
            var friendEntity = new FriendEntity()
            {
                user_id = friend.user_id,
                friend_id = findFrendEntity.id
            };
            if (friendEntity.user_id == friendEntity.friend_id)
                throw new UserNotFoundException();
            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
        public List<UserEntity> GetFriends(int userId)
        {
            var friends = new List<UserEntity>();
            foreach (int friendId in friendRepository.FindAllByUserId(userId).Select(fe => fe.friend_id))
            {
                var u = userRepository.FindById(friendId);
                if (u is null)
                    continue;
                friends.Add(u);
            }
            Console.WriteLine($"У Вас в друзьях {friends.Count} человек");
            return friends;
        }

    }
}
