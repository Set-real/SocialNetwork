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

        public FriendAddOrDeleteView(FriendService friendService)
        {
            FriendService = friendService;
        }

        public FriendAddOrDeleteView(UserService userService, FriendService friendService)
        {
            UserService = userService;
            FriendService = friendService;
        }

        public void Show(User user)
        {
            var Friend = new Friend();

            Console.WriteLine("Добро пожаловать на вкладку взаимодействия с друзьями! \n" +
                "Если вы хотите добавить друга нажмите 1 \n" +
                "Если вы хотите удалить друга нажмите 2");

            var resalt = Console.ReadLine();

            switch (resalt)
            {
                case "1":

                    Console.WriteLine("Введите имейл друга, которого хотите добавить");
                    user.Email = Console.ReadLine();                   
                    try
                    {
                        if (user.Email != null)
                        {
                            FriendService.Create(new Friend());
                            user = UserService.FindById(Friend.frend_id);
                            user = UserService.FindByEmail(user.Email);
                            SuccessMessage.Show($"{user.Email} добавлен в ваши друзья");

                        }
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

                case"2":

                    try
                    {
                        FriendService.Delete(Friend);

                        SuccessMessage.Show($"{Friend.frend_id} удален из ваших друзей");

                        user = UserService.FindById(Friend.frend_id);
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
