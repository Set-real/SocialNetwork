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
    public class FriendAddOrDeleteView
    {
        UserService UserService;
        FriendService FriendService;
        public FriendAddOrDeleteView(UserService userService, FriendService friendService)
        {
            UserService = userService;
            FriendService = friendService;
        }
        public void Show(User user)
        {
            Console.WriteLine("Добро пожаловать на вкладку взаимодействия с друзьями! \n" +
                "Если вы хотите добавить друга нажмите 1 \n");

            var resalt = Console.ReadLine();

            switch (resalt)
            {
                case "1":
                    AddFriendData addFriendData = new AddFriendData();
                    Console.WriteLine("Введите Email друга, которого хотите добавить");
                    addFriendData.FriendEmail = Console.ReadLine();

                    try
                    {
                        SuccessMessage.Show($"{addFriendData.FriendEmail} добавлен в ваши друзья");
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
