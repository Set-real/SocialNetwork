using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        UserRepository userRepository;
        MessageRepository messageRepository;
        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
            messageRepository = new MessageRepository();
        }

        public AddFriendData FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null)
                throw new UserNotFoundException();

            return new AddFriendData();
        }

        public void AddFriend(Friend friend)
        {
            if (friend.frend_id == 0)
                throw new UserNotFoundException();
            if (friend.user_id == 0)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                friend_id = friend.frend_id,
                user_id = friend.user_id
            };

            if (friendEntity == null)
                throw new Exception();
        }
    }
}
