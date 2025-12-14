using Bookify.Console.Services;
using Bookify.Domain.Entities.Users;

namespace Bookify.Console.Menu
{
    public class MenuManager
    {
        private readonly UserService _userService;

        public MenuManager(UserService userService)
        {
            _userService = userService;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                var choice = await ShowMainMenuAsync();

                if (choice == "1")
                {
                    await HandleSelectUserAsync();
                }
                else if (choice == "2")
                {
                    System.Console.WriteLine("Exiting application...");
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        private async Task<string> ShowMainMenuAsync()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("=== BOOKIFY - MAIN MENU ===");
            System.Console.WriteLine("1. Select User");
            System.Console.WriteLine("2. Exit");
            System.Console.Write("Select an option: ");
            return System.Console.ReadLine() ?? "";
        }

        private async Task HandleSelectUserAsync()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("=== AVAILABLE USERS ===");

            var users = await _userService.GetAllUsersAsync();
            var userList = users.ToList();

            if (!userList.Any())
            {
                System.Console.WriteLine("No users found in the database.");
                System.Console.WriteLine("Press any key to continue...");
                System.Console.ReadKey();
                return;
            }

            foreach (var user in userList)
            {
                System.Console.WriteLine($"ID: {user.Id} | Name: {user.Name}");
            }

            System.Console.WriteLine();
            System.Console.Write("Enter User ID: ");
            var input = System.Console.ReadLine();

            if (int.TryParse(input, out int userId))
            {
                var selectedUser = await _userService.GetUserByIdAsync(userId);
                if (selectedUser != null)
                {
                    await ShowUserMenuAsync(selectedUser);
                }
                else
                {
                    System.Console.WriteLine($"User with ID {userId} not found.");
                    System.Console.WriteLine("Press any key to continue...");
                    System.Console.ReadKey();
                }
            }
            else
            {
                System.Console.WriteLine("Invalid User ID.");
                System.Console.WriteLine("Press any key to continue...");
                System.Console.ReadKey();
            }
        }

        private async Task ShowUserMenuAsync(User user)
        {
            while (true)
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"=== USER MENU: {user.Name} (ID: {user.Id}) ===");
                System.Console.WriteLine("1. List User Books");
                System.Console.WriteLine("2. Go Back to Main Menu");
                System.Console.Write("Select an option: ");
                var choice = System.Console.ReadLine();

                if (choice == "1")
                {
                    await ShowUserBooksAsync(user.Id, user.Name);
                }
                else if (choice == "2")
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        private async Task ShowUserBooksAsync(int userId, string userName)
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"=== BOOKS FOR {userName.ToUpper()} ===");
            System.Console.WriteLine();

            var books = await _userService.GetUserBooksAsync(userId);
            var bookList = books.ToList();

            if (!bookList.Any())
            {
                System.Console.WriteLine("No books found for this user.");
            }
            else
            {
                for (int i = 0; i < bookList.Count; i++)
                {
                    var book = bookList[i];
                    System.Console.WriteLine($"{i + 1}. Title: {book.Title}");
                    System.Console.WriteLine($"   Author: {book.Author ?? "N/A"}");
                    System.Console.WriteLine($"   ISBN: {book.ISBN ?? "N/A"}");
                    System.Console.WriteLine($"   Published: {(book.PublishedDate.HasValue ? book.PublishedDate.Value.ToString("yyyy-MM-dd") : "N/A")}");
                    System.Console.WriteLine();
                }
            }

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}
