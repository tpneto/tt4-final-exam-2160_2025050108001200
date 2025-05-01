using beckend.Data;
using beckend.Models;
using Microsoft.EntityFrameworkCore;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Verify if the table already has data to avoid duplications
        if (!context.Bugs.Any())
        {
            // Adiciona 10 tarefas de exemplo
            var bugs = new List<BugItem>
            {
                new BugItem { Title = "Bug 1", Description = "First Bug description", Priority = "Low", IsResolved = false },
                new BugItem { Title = "Bug 2", Description = "Second Bug description", Priority = "High", IsResolved = false },
                new BugItem { Title = "Bug 3", Description = "Third Bug description", Priority = "Medium", IsResolved = true },
                new BugItem { Title = "Bug 4", Description = "Fourth Bug description", Priority = "Low", IsResolved = false },
                new BugItem { Title = "Bug 5", Description = "Fifth Bug description", Priority = "Low", IsResolved = false },
                new BugItem { Title = "Bug 6", Description = "Sixth Bug description", Priority = "High", IsResolved = true },
                new BugItem { Title = "Bug 7", Description = "Seventh Bug description", Priority = "High", IsResolved = false },
                new BugItem { Title = "Bug 8", Description = "Eighth Bug description", Priority = "Medium", IsResolved = true },
                new BugItem { Title = "Bug 9", Description = "Ninth Bug description", Priority = "Low", IsResolved = false },
                new BugItem { Title = "Bug 10", Description = "Tenth Bug description", Priority = "High", IsResolved = false }
            };

            context.Bugs.AddRange(bugs);
            context.SaveChanges();
        }
    }
}