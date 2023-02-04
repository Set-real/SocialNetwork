using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    /// <summary>
    /// Бизнес-логика для добавления в друзья
    /// </summary>
    public class FriendView
    {
        UserService userService;
        FriendService friendService;
        public FriendView()
        {
            userService= new UserService();
            friendService= new FriendService();
        }
        public void Show(User user)
        {
            Console.WriteLine("Добро пожаловать на вкладку взаимодействия с друзьями! \n" +
                "Если вы хотите добавить друга нажмите 1 \n");

            friendService.GetFriends(user.Id);

            var resalt = Console.ReadLine();

            switch (resalt)
            {
                case "1":
                    Console.WriteLine("Введите Email друга, которого хотите добавить");
                    string email = Console.ReadLine();

                    try
                    {
                        friendService.AddFriend(email);
                        SuccessMessage.Show($"{email} добавлен в ваши друзья");
                    }
                    catch (UserNotFoundException)
                    {
                        AlertMessage.Show("Пользователь не найден!");
                    }

                    catch (ArgumentNullException)
                    {
                        AlertMessage.Show("Введите корректное значение!");
                    }

                    catch (Exception)
                    {
                        AlertMessage.Show("Произошла ошибка при отправке сообщения!");
                    }

                    break;
            }
        }
    }
}
