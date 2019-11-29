namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;

	public static class Bonus
	{
		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
            var user = context
                .Users
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return $"User {username} not found";
            }

            var targetEmail = context
                .Users
                .FirstOrDefault(u => u.Email == newEmail);

            if (targetEmail != null)
            {
                return $"Email {newEmail} is already taken";
            }

            user.Email = newEmail;
            context.Users.Update(user);
            context.SaveChanges();

            return $"Changed {user.Username}'s email successfully";
		}
	}
}
